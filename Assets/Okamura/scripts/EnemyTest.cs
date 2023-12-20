using DG.Tweening;
using System.Collections;
using Unity.Collections;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamage
{
    [Tooltip("�G�l�~�[��HP")]
    [SerializeField] float _hp = 2;
    [Tooltip("�v���C���[�ɋ߂Â�����")]
    [SerializeField] float _distanceApproach = 10f;
    [Tooltip("�G�l�~�[�̈ړ��덷")]
    [SerializeField] float _tolerance = 2;
    [Tooltip("�v���C���[�ɋ߂Â��X�s�[�h")]
    [SerializeField] float _speed = 4;
    [Tooltip("�G���U��������N�[���^�C��")]
    [SerializeField] float _atkCt = 2f;
    [Tooltip("�G�l�~�[�̎��")]
    [SerializeField] public Enemystate _enemy;
    [Tooltip("�G�l�~�[�̎��S���̉��o")]
    [SerializeField] GameObject _deathEffect;
    [Tooltip("�����_���ɑI�΂��G�l�~�[�̍U����")]
    [SerializeField] float[] _atkDmgs = { 3, 6, 12 };
    [Tooltip("�G�l�~�[�̍U����")]
    [SerializeField, ReadOnly] float _dmg;
    [Tooltip("�^�b�N���̋O��")]
    [SerializeField] Ease _ease = Ease.OutElastic;
    [Tooltip("�_���[�W���󂯂����̃m�b�N�o�b�N�̋���")]
    [SerializeField] float _knockbackValue = 0.7f;
    [Tooltip("�_���[�W���󂯂����̃m�b�N�o�b�N��y���W")]
    [SerializeField] float _knockbackY = 1f;
    GameObject _player;
    Rigidbody _rb;
    Material _material;
    bool _attackable = true;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<Material>();
        _dmg = _atkDmgs[Random.Range(0, _atkDmgs.Length - 1)];
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        Vector3 playerdirection = _player.transform.position - this.transform.position;
        playerdirection.y = 0;
        _rb.transform.forward = playerdirection.normalized;
        if (_enemy == Enemystate.EnemyA)
        {
            if (playerdirection.magnitude >= _tolerance)
            {
                _rb.velocity = playerdirection.normalized * _speed;
            }
            else
            {
                _rb.velocity = Vector3.zero;
                Attack(playerdirection);
            }
        }
        else if (_enemy == Enemystate.EnemyB)
        {
            if (playerdirection.magnitude >= _distanceApproach)
            {
                _rb.velocity = playerdirection.normalized * _speed;
            }
            else if (playerdirection.magnitude + _tolerance <= _distanceApproach)
            {
                _rb.velocity = -playerdirection.normalized * _speed;
            }
            else
            {
                _rb.velocity = Vector3.zero;
            }
        }
    }
    void Attack(Vector3 attackVec)
    {//�A�j���C�^�[�̐��ڂƃN�[���^�C������
        if (_attackable) 
        {//�U������
            if(_enemy == Enemystate.EnemyA)
            {
                StartCoroutine(ITackle(attackVec, 0.4f, 0f));
            }
            else if (_enemy == Enemystate.EnemyB)
            {

            }
            //�N�[���^�C���J�n
            StartCoroutine(IAtkCt());
        }
    }
    
    IEnumerator ITackle(Vector3 attackVec, float flo, float rayAppear)
    {
        _rb.transform.DOMove(_player.transform.position - attackVec.normalized, flo).SetEase(_ease);
        yield return new WaitForSeconds(rayAppear);
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 0.5f, LayerMask.GetMask("Player")))
        {
            hit.collider.gameObject.TryGetComponent(out IDamage player);
            if (player != null) 
            {
                player.AddDamage(_dmg);
            }
            //Debug.Log(hit.transform.name);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * 0.5f, 0.5f);
    }
    IEnumerator IAtkCt()//�i�b��j�U���̃N�[���^�C��������
    {
        _attackable = false;
        yield return new WaitForSeconds(_atkCt);
        _attackable = true;
    }
    //�G�l�~�[�ւ̍U�������������ۂɌĂ�
    public void AddDamage(float damageValue)
    {
        _hp -= damageValue;
        StartCoroutine(IDamaged(0.3f));
    }
    IEnumerator IDamaged(float knockbackTime)
    {
        _rb.transform.DOMove((-_rb.transform.forward + new Vector3(0, _knockbackY, 0 )) * _knockbackValue, knockbackTime);
        yield return new WaitForSeconds(knockbackTime);
        if (_hp <= 0)
        {
            DeathEnemy();
        }
    }
    void DeathEnemy()
    {
        //�G�l�~�[�̃L���J�E���g�𑝂₷�������Ă�
        if (_deathEffect != null)
        {
            _deathEffect.transform.position = _rb.transform.position;
            Instantiate(_deathEffect);
        }
        if(_material != null)
        {
            Destroy(_material);
            _material = null;
        }
        Destroy(this.gameObject);
    }

}
