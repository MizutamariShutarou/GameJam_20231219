using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject Creditimag;
    public GameObject Result;

    public void GameStart()
    {
        SceneStateManager.instance.LoadScene(SceneType.Main);
        Title.SetActive(false);
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
        SceneStateManager.instance.LoadScene(SceneType.Real);
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
