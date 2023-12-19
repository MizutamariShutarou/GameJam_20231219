using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeClip : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlaySe(clip);
    }
}