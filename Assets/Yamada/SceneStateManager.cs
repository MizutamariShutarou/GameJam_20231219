using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    [SerializeField] string HP;

    public static SceneStateManager instance;

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

    private void LoadScene(SceneType LoadSceneName)
    {
        SceneManager.LoadScene(LoadSceneName.ToString());
    }

    void Start()
    {
        SceneStateManager.instance.LoadScene(SceneType.Main);
    }

}
