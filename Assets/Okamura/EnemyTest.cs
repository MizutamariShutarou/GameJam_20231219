using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [Tooltip("�v���C���[�𔭌����鋗��")]
    [SerializeField] float _distanceSearch = 10f;
    [Tooltip("�v���C���[�ɋ߂Â�����")]
    [SerializeField] float _distanceApproach = 10f;
    [Tooltip("�v���C���[�ɋ߂Â��X�s�[�h")]
    [SerializeField] float _speed = 3;
    [Tooltip("�G���U��������N�[���^�C��")]
    [SerializeField] float _atkCt = 2f;
    [SerializeField] public Enemystate _enemy;
    [Tooltip("�G�l�~�[�̎��S���̉��o")]
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
    {//�A�j���C�^�[�̐��ڂƃN�[���^�C������
        if (_attackable) 
        {//�U������

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
        //�G�l�~�[�̃L���J�E���g�𑝂₷�������Ă�

        Instantiate(_deathEffect);
        if(_material != null)
        {
            Destroy(_material);
            _material = null;
        }
        Destroy(this);
    }

}
