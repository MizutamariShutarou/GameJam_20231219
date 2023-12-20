using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip Title_BGM;
    [SerializeField] AudioClip ScaryDreams_BGM;
    [SerializeField] AudioClip PleasantDreams_BGM;
    [SerializeField] AudioClip Midnight_BGM;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(Title_BGM);
    }
}
