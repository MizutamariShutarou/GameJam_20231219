using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamManager : MonoBehaviour
{
    private bool _isChanged = default;
    void Start()
    {
        _isChanged = false;
        GameManager.Instance.SetLevel();
    }

    private void Update()
    {
        if(_isChanged)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneStateManager.instance.LoadScene(SceneType.RealWorld);
            _isChanged = true;
        }
    }
}
