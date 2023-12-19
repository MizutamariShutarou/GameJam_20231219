using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameter", menuName = "ScriptableObjects/Parameter/PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    [SerializeField, Header("�ړ����x"), Min(1f)]
    float _moveSpeed = 1f;

    [SerializeField, Header("�ő�HP")]
    int _maxHP = 0;

    [SerializeField, Header("�����U����")]
    float _firstAttackPower = 0;

    [SerializeField, Header("���G����")]
    float _invincibleTime = 0f;

    #region �A�N�Z�X
    /// <summary>�ړ����x</summary>
    public float MoveSpeed => _moveSpeed;

    /// <summary>�ő�HP</summary>
    public int MaxHP => _maxHP;

    /// <summary>�����U����</summary>
    public float FirstAttackPower => _firstAttackPower;

    /// <summary>���G����</summary>
    public float InvincibleTime => _invincibleTime;
    #endregion
}
