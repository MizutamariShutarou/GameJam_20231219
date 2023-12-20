using DG.Tweening;
using System.Collections;
using Unity.Collections;
using UnityEngine;

public class EnemyTest : MonoBehaviour, IDamage
{
    [Tooltip("�G�l�~�[�̃X�R�A�̎��")]
    [SerializeField] int[] _scores = {10, 10, 20, 30 };
    [Tooltip("�G�l�~�[�̃X�R�A")]
    [SerializeField] int _score = 20;
    [Tooltip("�G�l�~�[��HP�̎��")]
    [SerializeField] float[] _hps = { 1, 1, 2, 3 };
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
    [SerializeField] float _gizmoRadius = 0.5f;
    [SerializeField] float _gizmoLength = 1f;
    [SerializeField] Vector3 _gizmoY = new Vector3(0, 1f, 0);
    GameObject _player;
    //GameObject _spawner;
    ScoreManager _scoreManager;
    Rigidbody _rb;
    MeshRenderer _meshRen;
    bool _attackable = true;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _meshRen = GetComponent<MeshRenderer>();
        _dmg = _atkDmgs[Random.Range(0, _atkDmgs.Length - 1)];
        _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        _hp = _hps[GameManager.Instance.DreamLevel / 2];
        _score = _scores[GameManager.Instance.DreamLevel / 2];
        //_spawner = GameObject.FindWithTag("Spawner");
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
        if(Physics.SphereCast(transform.position + _gizmoY, _gizmoRadius, transform.forward, out hit, _gizmoLength, LayerMask.GetMask("Player")))
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
        Gizmos.DrawWireSphere(transform.position + _gizmoY + transform.forward * _gizmoLength, _gizmoRadius);
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
        IDamaged(0.3f);
    }
    void IDamaged(float knockbackTime)
    {
        transform.DOComplete();
        _rb.AddForce(_rb.transform.forward * knockbackTime, ForceMode.Impulse);
        Debug.Log("knockbacked");
        if (_hp <= 0)
        {
            DeathEnemy();
        }
    }
    void DeathEnemy()
    {
        _scoreManager.AddScore(_score);
        //Debug.Log(_spawner);
        //_spawner.GetComponent<Spawner>().DecreaseEnmCnt();
        if (_deathEffect != null)
        {
            _deathEffect.transform.position = _rb.transform.position;
            Instantiate(_deathEffect);
        }
        if(_meshRen != null)
        {
            Destroy(_meshRen);
            _meshRen = null;
        }
        Destroy(this.gameObject);
    }
}
