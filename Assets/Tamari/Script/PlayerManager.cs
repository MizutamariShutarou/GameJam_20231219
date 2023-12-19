using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameterController), typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    static PlayerManager _instance = default;
    public PlayerManager Instance => _instance;

    private Rigidbody _rb = default;

    private PlayerParameterController _playerParameterController = default;

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        _playerParameterController = GetComponent<PlayerParameterController>();
        _playerParameterController.InitializeParam();
    }

    public void ItemParamChangeActive(ParameterType parameterType, float value)
    {
        _playerParameterController.ItemEffectActive(parameterType, value);
    }
}
