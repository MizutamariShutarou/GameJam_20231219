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
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
    /*-----------------------------------*/
    public void ReturnTitle()
    {
        Result.SetActive(false);
    }
}
