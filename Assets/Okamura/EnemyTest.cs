using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [Tooltip("プレイヤーを発見する距離")]
    [SerializeField] float _distanceSearch = 10f;
    [Tooltip("プレイヤーに近づく距離")]
    [SerializeField] float _distanceApproach = 10f;
    [Tooltip("プレイヤーに近づくスピード")]
    [SerializeField] float _speed = 3;
    [Tooltip("敵が攻撃をするクールタイム")]
    [SerializeField] float _atkCt = 2f;
    [SerializeField] public Enemystate _enemy;
    [Tooltip("エネミーの死亡時の演出")]
    [SerializeField] GameObject _deathEffect;
    GameObject _player;
    Rigidbody _rb;
    Material _material;
    Animator _animator;
    bool _attackable = true;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<Material>();
    }

    void Update()
    {
        if (_enemy == Enemystate.EnemyA)
        {
            Vector3 playerdirection = _player.transform.position - this.transform.position;
            playerdirection.y = 0;
            if (playerdirection.magnitude >= 2)
            {
                _rb.velocity = playerdirection.normalized * _speed;
            }
            else
            {
                _rb.velocity = Vector3.zero;
            }
        }
        else if (_enemy == Enemystate.EnemyB)
        {
            Vector3 playerdirection = _player.transform.position - this.transform.position;
            playerdirection.y = 0;
            if (playerdirection.magnitude >= _distanceApproach)
            {
                _rb.velocity = playerdirection.normalized * _speed;
            }
            else if (playerdirection.magnitude + 2 <= _distanceApproach)
            {
                _rb.velocity = -playerdirection.normalized * _speed;
            }
            else
            {
                _rb.velocity = Vector3.zero;
            }
        }
    }

    void Attack()
    {//アニメイターの推移とクールタイムを回す
        if (_attackable) 
        {//攻撃処理

            StartCoroutine(IAtkCt());
        }
    }
    IEnumerator IAtkCt()
    {
        _attackable = false;
        yield return new WaitForSeconds(_atkCt);
        _attackable = true;
    }
    public void KillEnemy()
    {
        DeathEnemy();
    }
    void DeathEnemy()
    {
        //エネミーのキルカウントを増やす処理を呼ぶ

        Instantiate(_deathEffect);
        if(_material != null)
        {
            Destroy(_material);
            _material = null;
        }
        Destroy(this);
    }

}
