using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameter", menuName = "ScriptableObjects/Parameter/PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    [SerializeField, Header("ˆÚ“®‘¬“x"), Min(1f)]
    float _moveSpeed = 1f;

    [SerializeField, Header("Å‘åHP")]
    int _maxHP = 0;

    [SerializeField, Header("‰ŠúUŒ‚—Í")]
    float _firstAttackPower = 0;

    [SerializeField, Header("–³“GŠÔ")]
    float _invincibleTime = 0f;

    #region ƒAƒNƒZƒX
    /// <summary>ˆÚ“®‘¬“x</summary>
    public float MoveSpeed => _moveSpeed;

    /// <summary>Å‘åHP</summary>
    public int MaxHP => _maxHP;

    /// <summary>‰ŠúUŒ‚—Í</summary>
    public float FirstAttackPower => _firstAttackPower;

    /// <summary>–³“GŠÔ</summary>
    public float InvincibleTime => _invincibleTime;
    #endregion
}
