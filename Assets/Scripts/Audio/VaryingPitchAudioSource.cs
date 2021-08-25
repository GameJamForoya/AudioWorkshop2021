using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaryingPitchAudioSource : MonoBehaviour
{
    public AudioSource Source;
    public float OffsetRange;

    private float _pitchOrigin;

    // Start is called before the first frame update
    void Start()
    {
        _pitchOrigin = Source.pitch;
    }

    public void Play()
    {
        float offset = Random.Range(-OffsetRange, OffsetRange);
        float pitch = _pitchOrigin + offset;

        Source.pitch = pitch;
        Source.Play();
    }
}
