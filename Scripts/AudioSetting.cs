using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string BackgroundVolume = nameof(BackgroundVolume);
    private const string SoundVolume = nameof(SoundVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isMute = false;
    private float _minValue = 0.0001f;
    private float _maxValue = 1.0f;
    private float _minVolume = -80;
    private float _decibelVolumeStep = 20;
    private float _currentVolume = 0;

    public void SetMasterVolume(float volume)
    {
        ChangeVolume(volume, MasterVolume);
    }

    public void SetMusicVolume(float volume)
    {
        ChangeVolume(volume, BackgroundVolume);
    }

    public void SetSoundVolume(float volume)
    {
        ChangeVolume(volume, SoundVolume);
    }

    public void TurnOffMusic()
    {
        _isMute = !_isMute;

        if (_isMute)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _minVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _currentVolume);
        }
    }

    private void ChangeVolume(float volume, string nameMasterMixer)
    {
        _currentVolume = Mathf.Log10(Mathf.Clamp(volume, _minValue, _maxValue)) * _decibelVolumeStep;
        _mixer.audioMixer.SetFloat(nameMasterMixer, _currentVolume);
    }
}
