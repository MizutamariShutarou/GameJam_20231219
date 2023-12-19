using UnityEngine;

public enum Enemystate
{
    [Tooltip("プレイヤーに対してできる限り接近する行動パターン")]
    EnemyA,
    [Tooltip("プレイヤーに対して一定距離を保つ行動パターン")]
    EnemyB
}