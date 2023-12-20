using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System;

public class Fade : MonoBehaviour
{
    [SerializeField, Header("Image")]
    Image _image;
    [SerializeField, Header("フェイドインする時間")]
    public float _fadeInTime;
    [SerializeField, Header("フェイドアウトする時間")]
    public float _fadeOutTime;

    public Action _callback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FadeIn(Action callback = default)
    {
        _image.DOFade(1f, _fadeInTime).OnComplete(() => ActiveEvent(callback));
    }

    public void FadeOut(Action callback)
    {
        _image.DOFade(0f, _fadeInTime).OnComplete(() => ActiveEvent(callback));

        //await _image.DOFade(1f, _fadeInTime).AsyncWaitForCompletion();
        //SceneManager.LoadScene(sceneNum);
    }

    private void ActiveEvent(Action callback = default)
    {
        _callback = callback;
        _callback?.Invoke();
    }
}
