using UnityEngine;

public class PlayerParameterController : MonoBehaviour
{
    [SerializeField, Header("パラメータデータ")]
    PlayerParameter _playerParam = default;

    private static float _moveSpeed = default;

    private static float _hp = default;

    private static float _attackPower = default;

    private float _rotateNum = default;

    public static float MoveSpeed => _moveSpeed;

    public static float HP => _hp;

    public static float AttackPower => _attackPower;

    public float RotateNum => _rotateNum;

    public void InitializeParam()
    {
        _hp = _playerParam.MaxHP;
        _attackPower = _playerParam.FirstAttackPower;
        _moveSpeed = _playerParam.MoveSpeed;
        _rotateNum = _playerParam.RotateNum;
    }

    public void ChangeHp(float healAmount)
    {
        _hp = (0 < healAmount) ? Mathf.Min(_playerParam.MaxHP, _hp + healAmount) : Mathf.Max(0, _hp + healAmount);
    }

    public void ChangeAttackPower(float changeAttackPowerAmount)
    {
        _attackPower = (0 < changeAttackPowerAmount) ?
            Mathf.Min(_playerParam.FirstAttackPower, _attackPower + changeAttackPowerAmount)
                : Mathf.Max(_playerParam.FirstAttackPower, _attackPower + changeAttackPowerAmount);
    }

    public void ChangeSpeed(float changeSpeedAmount)
    {
        _moveSpeed = (0 < changeSpeedAmount) ?
            Mathf.Min(_playerParam.MoveSpeed, _moveSpeed + changeSpeedAmount)
                : Mathf.Max(_playerParam.MoveSpeed, _moveSpeed + changeSpeedAmount);
    }
}
