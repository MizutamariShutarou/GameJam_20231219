using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameterController : MonoBehaviour
{
    [SerializeField, Header("パラメータデータ")]
    PlayerParameter _playerParam = default;

    private float _moveSpeed = default;

    private float _hp = default;

    private float _attackPower = default;

    public float MoveSpeed => _moveSpeed;

    public float HP => _hp;

    public float AttackPower => _attackPower;

    public void InitializeParam()
    {
        _hp = _playerParam.MaxHP;
        _attackPower = _playerParam.FirstAttackPower;
        _moveSpeed = _playerParam.MoveSpeed;
    }

    public void ChangeHp(float healAmount)
    {
        _hp += healAmount;
        Debug.Log(_hp);
    }

    public void ChangeAttackPower(float changeAttackPowerAmount)
    {
        _attackPower += changeAttackPowerAmount;
    }

    public void ChangeSpeed(float changeSpeedAmount)
    {
        _moveSpeed += changeSpeedAmount;
    }
}
