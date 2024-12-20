using UnityEngine.Audio;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Tutor
{
    public class SettingsWindow : Window
    {
        [Space]
        [SerializeField] AudioMixerGroup m_masterGroup;
        [SerializeField] Slider m_slider;

        [Inject] SaveLoadManager _saveLoadManager;



        float _masterVolume;

        [SaveLoad("MasterVolume")]
        public float MasterVolume
        {
            get
            {
                return _masterVolume;
            }
            set
            {
                _masterVolume = value;
                SetVolume(_masterVolume);
                SetSliderValue();
            }
        }

        public override void Disable() 
        { 
            base.Disable();
            _saveLoadManager.Save();
        }



        void Awake()
        {
            DisableInstantly();
            _saveLoadManager.Register(this);
        }

        void SetSliderValue()
        {
            m_slider.value = _masterVolume;
        }

        public void SetVolume(float volume)
        {
            _masterVolume = volume;

            m_masterGroup.audioMixer.SetFloat("Volume", _masterVolume);

            if (_masterVolume <= -50)
            {
                m_masterGroup.audioMixer.SetFloat("Volume", -80);
            }

            SetSliderValue();
        }

        public void Mute()
        {
            m_masterGroup.audioMixer.SetFloat("Volume", -80);
        }

        public void Unmute()
        {
            m_masterGroup.audioMixer.SetFloat("Volume", _masterVolume);
        }
    }
}