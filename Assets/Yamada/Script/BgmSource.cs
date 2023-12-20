using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSource : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlayBgm(clip);
    }
}
