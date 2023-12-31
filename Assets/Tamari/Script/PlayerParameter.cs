using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameter", menuName = "ScriptableObjects/Parameter/PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    [SerializeField, Header("移動速度"), Min(1f)]
    float _moveSpeed = 1f;

    [SerializeField, Header("最大HP")]
    int _maxHP = 0;

    [SerializeField, Header("初期攻撃力")]
    float _firstAttackPower = 0;

    [SerializeField, Header("無敵時間")]
    float _invincibleTime = 0f;

    [SerializeField, Header("回転補正値")]
    float _rotateNum = 0f;

    #region アクセス
    /// <summary>移動速度</summary>
    public float MoveSpeed => _moveSpeed;

    /// <summary>最大HP</summary>
    public int MaxHP => _maxHP;

    /// <summary>初期攻撃力</summary>
    public float FirstAttackPower => _firstAttackPower;

    /// <summary>無敵時間</summary>
    public float InvincibleTime => _invincibleTime;

    public float RotateNum => _rotateNum;
    #endregion
}
