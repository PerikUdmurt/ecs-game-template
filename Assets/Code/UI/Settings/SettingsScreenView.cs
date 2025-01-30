using System;
using System.Collections.Generic;
using Code.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Settings
{
    public class SettingsScreenView : UIScreenView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _closeZone;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Slider _coundsSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Dropdown _languageDropdown;
        [SerializeField] private Dropdown _resolutionDropdown;
        
        public IObservable<Unit> OnCloseClicked => 
            _closeButton.OnClickAsObservable()
                .Merge(_closeZone.OnClickAsObservable());

        public IObservable<Unit> OnSaveClicked => _saveButton.OnClickAsObservable();
        public IObservable<Unit> OnCancelClicked => _cancelButton.OnClickAsObservable();
        public IObservable<float> OnSoundsValueChanged => _coundsSlider.OnValueChangedAsObservable();
        public IObservable<float> OnMusicValueChanged => _musicSlider.OnValueChangedAsObservable();
        public IObservable<int> OnResolutionValueChanged => _resolutionDropdown.OnValueChangedAsObservable();
        public IObservable<int> OnLanguageValueChanged => _languageDropdown.OnValueChangedAsObservable();

        public void SetMusicSliderValue(float musicValue) =>
            _musicSlider.value = musicValue;
        
        public void SetSoundsSliderValue(float soundsValue) =>
            _coundsSlider.value = soundsValue;
        
        
        
        public void SetResolutionDropdownOptions(List<Dropdown.OptionData> options, int value)
        {
            _resolutionDropdown.ClearOptions();
            _resolutionDropdown.options = options;
            _resolutionDropdown.value = value;
        }
        
        public void SetLanguageDropdownOptions(List<Dropdown.OptionData> options, int value)
        {
            _languageDropdown.ClearOptions();
            _languageDropdown.options = options;
            _languageDropdown.value = value;
        }
    }
}