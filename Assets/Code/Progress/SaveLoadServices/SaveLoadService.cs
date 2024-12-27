using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Services.FileDataServices;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.Progress.SaveLoadServices
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly ProgressContext _context;
        private readonly IProgressProvider _progressProvider;
        private readonly IFileDataService _fileDataService;

        public SaveLoadService(ProgressContext context, IProgressProvider progressProvider)
        {
            _context = context;
            _progressProvider = progressProvider;
            _fileDataService = new FileDataService(Application.persistentDataPath, true);
        }

        public void SaveProgress()
        {
            PreserveProgressEntities();
            string json = _progressProvider.ProgressData.ToJson();
            _fileDataService.Save(json, "TestData.json");
            Debug.Log($"[SAVEDLOADSERVICE]: Saved progress data to path {Application.persistentDataPath} with name TestData.json and with data: {json}]");
        }

        public void LoadProgress()
        {
            string json = _fileDataService.LoadJson("TestData.json");
            
            if (json == null)
            {
                CreateNewProgress();
                json = _fileDataService.LoadJson("TestData.json");
            }

            ProgressData data = json.FromJson<ProgressData>();
            _progressProvider.SetProgressData(data);
            CreateProgressEntities();
            Debug.Log($"[SAVEDLOADSERVICE]: Loaded progress data with data: {json}]");
        }

        private void CreateNewProgress()
        {
            _progressProvider.CreateNewProgressData();
            string json = _progressProvider.ProgressData.ToJson();
            _fileDataService.Save(json, "TestData.json");
            Debug.Log($"[SAVEDLOADSERVICE]: Created new progress data to path {Application.persistentDataPath} with name TestData.json]"); 
        }

        private void CreateProgressEntities()
        {
            List<EntitySnapshot> snapShots = _progressProvider.ProgressData.data.entitySnapshots;
            foreach (EntitySnapshot snapshot in snapShots)
            {
                _context
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveProgressEntities()
        {
            _progressProvider.ProgressData.data.entitySnapshots = _context
                .GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSaveEntity())
                .ToList();
        }

        private bool RequiresSave(ProgressEntity entity)
        {
            return entity.GetComponents().Any(c => c is IProgressComponent);
        }
    }
}