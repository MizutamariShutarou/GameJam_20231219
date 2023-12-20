using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerParameterController), typeof(PlayerController), typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour, IDamage
{
    //static PlayerManager _instance = default;
    //public PlayerManager Instance => _instance;

    private PlayerParameterController _playerParameterController = default;

    private PlayerController _playerController = default;

    public PlayerParameterController PlayerParameterController => _playerParameterController;

    public PlayerController PlayerController => _playerController;

    public void AddDamage(float damageValue)
    {
        _playerParameterController.Damage(damageValue);
        if(PlayerParameterController.HP <= 0)
        {
            Debug.Log("éÄñS");
        }
    }

    //private void Awake()
    //{
    //    if(Instance == null)
    //    {
    //        _instance = this;
    //        Initialize();
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void Initialize()
    {
        _playerParameterController = GetComponent<PlayerParameterController>();
        _playerParameterController.InitializeParam();

        _playerController = GetComponent<PlayerController>();
        _playerController.Initialize(_playerParameterController);

    }

    public void ItemParamChangeActive(string parameterType, float value)
    {
        if(parameterType == ParameterType.Hp.ToString())
        {
            _playerParameterController.ChangeHp(value);
        }
        else if(parameterType == ParameterType.Attack.ToString())
        {
            _playerParameterController.ChangeAttackPower(value);
        }
        else if (parameterType == ParameterType.Speed.ToString())
        {
            _playerParameterController.ChangeSpeed(value);
        }
        else
        {
            Debug.Log("ä˙ë“Ç≥ÇÍÇƒÇ¢Ç»Ç¢ï∂éöóÒÇ™ìnÇ≥ÇÍÇ‹ÇµÇΩÅB");
        }
    }
}
