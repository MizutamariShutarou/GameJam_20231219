using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _height = 0;

    [SerializeField, Header("武器の当たり判定")]
    private Vector3 _attackVec = default;

    [SerializeField, Header("武器の当たり判定の中心")]
    private Vector3 _attackRangeCenter = default;

    [SerializeField, Header("剣オブジェクト")]
    private GameObject _sword = default;
    
    private PlayerParameterController _paramController = default;

    private Vector3 _vec = default;
    private Rigidbody _rb = default;

    public void Initialize(PlayerParameterController controller)
    {
        _paramController = controller;
        _rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, _height, 0);
    }

    private void FixedUpdate()
    {
        Speed();
        Move();

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    private void Speed()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float rX = x * PlayerParameterController.MoveSpeed * Time.deltaTime;
        float rY = y * PlayerParameterController.MoveSpeed * Time.deltaTime;

        //現在のX,Zベクトルに上の処理で取得した値を渡す。
        _vec = Camera.main.transform.TransformDirection(new Vector3(x, 0, y).normalized);
        transform.forward = Vector3.Slerp(transform.forward, new Vector3(rX, 0, rY), Time.deltaTime * _paramController.RotateNum);
        _vec.y = 0;
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_vec.x * PlayerParameterController.MoveSpeed, _rb.velocity.y, _vec.z * PlayerParameterController.MoveSpeed);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapBox(GetAttackRangeCenterOfSword(), _attackVec, _sword.transform.rotation);

        foreach (var col in cols)
        {
            if (col.gameObject != this.gameObject && col.gameObject != _sword.gameObject && col.gameObject.TryGetComponent(out IDamage enemy))
            {
                enemy.AddDamage(PlayerParameterController.AttackPower);
                Debug.Log("Attack!!");
            }
        }
    }

    private Vector3 GetAttackRangeCenterOfSword()
    {
        Vector3 center = _sword.transform.position + _sword.transform.forward * _attackRangeCenter.z
           + _sword.transform.up * _attackRangeCenter.y
           + _sword.transform.right * _attackRangeCenter.x;
        return center;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(GetAttackRangeCenterOfSword(), _attackVec);
    }
}
