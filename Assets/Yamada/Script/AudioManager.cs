using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]AudioSource bgmAudioSource;
    [SerializeField]AudioSource seAudioSource;

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

    public void PlayBGM(AudioClip clip)
    {
        bgmAudioSource.clip = clip;

        if (clip != null)
        {
            return;
        }

        bgmAudioSource.Play();
    }

    public void PlaySE(AudioClip clip)
    {
        seAudioSource.clip = clip;

        if (clip != null)
        {
            return;
        }

        seAudioSource.Play();
    }
}
