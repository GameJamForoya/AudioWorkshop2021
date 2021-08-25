using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float maxVolume;
    public float fadeTimeInSeconds;

    private Song _currentSong;

    public void PlaySong(Song song)
    {
        if (_currentSong)
        {
            _currentSong.FadeOut(fadeTimeInSeconds);
        }

        _currentSong = song;
        _currentSong.FadeIn(fadeTimeInSeconds, maxVolume);
    }
}