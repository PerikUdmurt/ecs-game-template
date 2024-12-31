using Code.Services.PlayerSettingsServices;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace Code.UI.Settings
{
    [UsedImplicitly]
    public class SettingsScreenController : UIScreenController<SettingsScreenView>
    {
        private readonly IPlayerSettingService _playerSettingService;

        public SettingsScreenController(IPlayerSettingService playerSettingService)
        {
            _playerSettingService = playerSettingService;
        }
        
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnCloseClicked
                .Subscribe(_ => HideView().Forget())
                .AddTo(disposables);
            
            _view.OnCancelClicked
                .Subscribe(_ => OnCancelClicked())
                .AddTo(disposables);
            
            _view.OnSaveClicked
                .Subscribe(_ => OnSaveClicked())
                .AddTo(disposables);
            
            _view.OnLanguageValueChanged
                .Subscribe(OnLanguageChange)
                .AddTo(disposables);
            
            _view.OnMusicValueChanged
                .Subscribe(OnMusicChange)
                .AddTo(disposables);
            
            _view.OnResolutionValueChanged
                .Subscribe(OnResolutionChange)
                .AddTo(disposables);
            
            _view.OnSoundsValueChanged
                .Subscribe(OnSoundsChange)
                .AddTo(disposables);
            
            return UniTask.CompletedTask;
        }

        private void OnResolutionChange(int value)
        {
            Debug.LogWarning($"$[SettingsScreenController] OnResolutionChange not assigned. Value = {value}");
            //_playerSettingService.SetResolution();
        }

        private void OnMusicChange(float value)
        {
            _playerSettingService.SetMusicVolume(value);
        }
        
        private void OnSoundsChange(float value)
        {
            _playerSettingService.SetSoundVolume(value);
        }

        private void OnLanguageChange(int value)
        {
            Debug.LogWarning($"$[SettingsScreenController] OnLanguageChange not assigned. Value = {value}");
        }

        private void OnCancelClicked()
        {
            Debug.LogWarning("[SettingsScreenController] OnCancelClicked not assigned");
        }
        
        private void OnSaveClicked()
        {
            Debug.LogWarning("[SettingsScreenController] OnSaveClicked not assigned");
        }
    }
}