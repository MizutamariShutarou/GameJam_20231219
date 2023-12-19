using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameterController : MonoBehaviour
{
    [SerializeField, Header("�p�����[�^�f�[�^")]
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

    public void ItemEffectActive(ParameterType parameterType, float value)
    {
        switch (parameterType)
        {
            case ParameterType.Hp:
                _hp = (0 < value) ? Mathf.Min(_playerParam.MaxHP, _hp + value) : Mathf.Max(0, _hp - value);
                break;
            default:
                Debug.LogError("���̃p�����[�^�[�𑀍삷�鏈����������Ă��܂���");
                break;
        }
    }
}
