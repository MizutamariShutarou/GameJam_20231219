using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _height = 0;
    
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
        Attack();
    }
    private void Speed()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float rX = x * _paramController.MoveSpeed * Time.deltaTime;
        float rY = y * _paramController.MoveSpeed * Time.deltaTime;

        //現在のX,Zベクトルに上の処理で取得した値を渡す。
        _vec = Camera.main.transform.TransformDirection(new Vector3(x, 0, y).normalized);
        transform.forward = Vector3.Slerp(transform.forward, new Vector3(rX, 0, rY), Time.deltaTime * _paramController.RotateNum);
        _vec.y = 0;
    }

    private void Move()
    {
        _rb.velocity = new Vector3(_vec.x * _paramController.MoveSpeed, _rb.velocity.y, _vec.z * _paramController.MoveSpeed);
    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
        }
    }
}
