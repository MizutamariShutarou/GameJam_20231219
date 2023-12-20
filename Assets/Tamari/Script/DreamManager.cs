using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamManager : MonoBehaviour
{
    private bool _isStart = default;
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
        if (PlayerParameterController.HP <= 0)
        {
            SceneStateManager.instance.LoadScene(SceneType.Result);
            _isChanged = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameManager.Instance.TimeManager.ReduceTimere();
            SceneStateManager.instance.LoadScene(SceneType.RealWorld);
            _isChanged = true;
        }
    }
}
