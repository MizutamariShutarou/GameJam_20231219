using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System;

public class ButtonManager : MonoBehaviour
{
    public GameObject Creditimag;
    [SerializeField]
    Fade _fade;

    async void GameStart()
    {
        //_fade.FadeIn();
        //await UniTask.Delay(TimeSpan.FromSeconds(_fade._fadeOutTime));
        //SceneStateManager.instance.LoadScene(SceneType.Main);
        GameManager.Instance.FadeIn(() => SceneStateManager.instance.LoadScene(SceneType.Main));
    }

    public void Credit()
    {
        Creditimag.SetActive(true);
    }

    public void CreditClose()
    {
        Creditimag.SetActive(false);
    }
    
    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    /*-----------------------------------*/
    public void ReturnTitle()
    {
        SceneStateManager.instance.LoadScene(SceneType.Title);
        //Result.SetActive(false);
    }

    public void ToReal()
    {
        SceneStateManager.instance.LoadScene(SceneType.RealWorld);
    }
        
    public void ToDream()
    {

        SceneStateManager.instance.LoadScene(SceneType.Dream);
    }

    public void ToResult()
    {
        SceneStateManager.instance.LoadScene(SceneType.Result);
    }
}
