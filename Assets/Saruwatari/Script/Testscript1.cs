using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Testscript1 : MonoBehaviour
{
    public float _waitTime = 2;
    public GameObject _text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _text.SetActive(true);
            await UniTask.Delay(TimeSpan.FromSeconds(_waitTime));
            SceneStateManager.instance.LoadScene(SceneType.Dream);
        }
    }
}
