using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneStateManager.instance.LoadScene(SceneType.Real);
        }
    }
}
