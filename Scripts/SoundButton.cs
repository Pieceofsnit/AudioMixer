using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Button _buttonSound;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _buttonSound.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _buttonSound.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}