using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip Swith_SE;
    [SerializeField] AudioClip Flapping_SE;
    [SerializeField] AudioClip Decision_SE;
    [SerializeField] AudioClip Damage_SE;
    [SerializeField] AudioClip Attack_SE;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySE(Swith_SE);
    }
}
