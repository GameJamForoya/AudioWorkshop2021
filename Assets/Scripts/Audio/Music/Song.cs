using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Song : MonoBehaviour
{
    private const float AccuracyFactor = 0.01f;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.0f;

        if (!_audioSource.playOnAwake)
        {
            _audioSource.Play();
        }
    }

    public void FadeOut(float fadeSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutRoutine(fadeSpeed));
    }

    public void FadeIn(float fadeSpeed, float maxVolume)
    {
        var maxVolume01 = Mathf.Clamp01(maxVolume);

        StopAllCoroutines();
        StartCoroutine(FadeInRoutine(fadeSpeed, maxVolume01));
    }

    private IEnumerator FadeOutRoutine(float fadeSpeed)
    {
        while (_audioSource.volume > AccuracyFactor)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        _audioSource.volume = 0.0f;
    }

    private IEnumerator FadeInRoutine(float fadeSpeed, float maxVolume)
    {
        while (_audioSource.volume < maxVolume - AccuracyFactor)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        _audioSource.volume = maxVolume;
    }
}