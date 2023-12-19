using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgmAudioSource;
    private AudioSource seAudioSource;

    public static AudioManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBgm(AudioClip clip)
    {
        bgmAudioSource.clip = clip;

        if (clip != null)
        {
            return;
        }

        bgmAudioSource.Play();
    }

    public void PlaySe(AudioClip clip)
    {
        seAudioSource.clip = clip;

        if (clip != null)
        {
            return;
        }

        seAudioSource.Play();
    }
}
