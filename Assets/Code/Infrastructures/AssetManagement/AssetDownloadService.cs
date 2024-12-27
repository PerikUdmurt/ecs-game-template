﻿using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetDownloadService : IAssetDownloadService
    {
        //ResourceLocator - внутренний механизм для быстрого доступа к ресурсам
        //Рассматривай как механизм, который предоставляет инструментарий для работы со списком ресурсов
        //Из них можно взять ResourceLocation, ключ (наравне с ключом-названием ассета и лэйблом).
        private List<IResourceLocator> _catalogLocators;
        private long _downloadSize;
        private readonly IAssetDownloadReporter _downloadReporter;

        public AssetDownloadService(IAssetDownloadReporter downloadReporter)
        {
            _downloadReporter = downloadReporter;
        }

        public async UniTask InitializeDownloadDataAsync()
        {
            await Addressables.InitializeAsync().ToUniTask();
            await UpdateCatalogAsync();
            await UpdateDownloadSizeAsync();
        }

        public float GetDownloadSizeMb()
            => SizeToMb(_downloadSize);

        public async UniTask UpdateContentAsync()
        {
            if (_catalogLocators == null)
                await UpdateCatalogAsync();

            IList<IResourceLocation> locations = await RefreshResourceLocations(_catalogLocators);
            if (locations.IsNullOrEmpty())
                return;

            await DownloadContentWithPreciseProgress(locations);
        }

        private async UniTask DownloadContent(IList<IResourceLocation> locations)
        {
            var downloadTask = Addressables
            .DownloadDependenciesAsync(locations, autoReleaseHandle: true)
            .ToUniTask(progress: _downloadReporter);

            await downloadTask;

            if (downloadTask.Status.IsFaulted())
                Debug.LogError("Error while downloading catalog dependencies");

            _downloadReporter.Reset();
        }

        private async UniTask DownloadContentWithPreciseProgress(IList<IResourceLocation> locations)
        {
            AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync(locations);
            while (!downloadHandle.IsDone && downloadHandle.IsValid())
            {
                await UniTask.Delay(100);
                _downloadReporter.Report(downloadHandle.GetDownloadStatus().Percent);
            }

            _downloadReporter.Report(1);
            if (downloadHandle.Status == AsyncOperationStatus.Failed)
                Debug.LogError("Error while downloading catalog dependencies");

            if (downloadHandle.IsValid())
                Addressables.Release(downloadHandle);

            _downloadReporter.Reset();
        }

        private async UniTask UpdateCatalogAsync()
        {
            List<string> catalogToUpdate = await Addressables.CheckForCatalogUpdates().ToUniTask();

            //Если каталоги не нуждаются в обновлении то просто получаем ресурслокаторы
            if (catalogToUpdate.IsNullOrEmpty())
            {
                _catalogLocators = Addressables.ResourceLocators.ToList();
                return;
            }

            //Если есть обновления, то обновляем.
            _catalogLocators = await Addressables.UpdateCatalogs(catalogToUpdate).ToUniTask();
        }

        private async UniTask UpdateDownloadSizeAsync()
        {
            IList<IResourceLocation> locations = await RefreshResourceLocations(_catalogLocators);

            if (locations.IsNullOrEmpty())
                return;

            _downloadSize = await Addressables
                .GetDownloadSizeAsync(locations)
                .ToUniTask();
        }

        private async UniTask<IList<IResourceLocation>> RefreshResourceLocations(IEnumerable<IResourceLocator> catalogLocator)
        {
            Debug.Log(catalogLocator == null);

            IEnumerable<object> keysToCheck = catalogLocator.SelectMany(x => x.Keys);

            return await Addressables
                .LoadResourceLocationsAsync(keysToCheck, Addressables.MergeMode.Union)
                .ToUniTask();
        }

        private float SizeToMb(long downloadSize)
            => downloadSize * 1f / 1048576;
    }
}