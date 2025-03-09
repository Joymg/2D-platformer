using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource targetAudioSource;
    [Range(0f, 1f)] public float volume = 1f;

    public void Play()
    {
        if (!clip)
            return;
        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clip);
    }

    public void PlayClip(AudioClip clipToPlay = null)
    {
        if (!clipToPlay)
            clipToPlay = clip;
        if (!clipToPlay)
            return;
        targetAudioSource.volume = volume;
        targetAudioSource.PlayOneShot(clipToPlay);
        
    }
}
