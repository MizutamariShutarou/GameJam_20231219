using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("�G�l�~�[�̐����b���̈ꗗ")]
    [SerializeField] float[] _spawnCTs = { 7, 6, 5, 4, 3, 2 };
    [Tooltip("���݂̃G�l�~�[�̐����b��")]
    [SerializeField, ReadOnly] float _enteredSpawnCT = 4;
    [Tooltip("��������G�l�~�[")]
    [SerializeField] GameObject _spawnObj;
    [Tooltip("��������G�l�~�[��Y���W")]
    [SerializeField] float _spawnY = 1;
    [Tooltip("�G�l�~�[�𐶐�����͈�")]
    [SerializeField] Vector3 _spawnSize = new Vector3(5, 5, 5);
    [Tooltip("�G�l�~�[����������Ȃ��v���C���[�Ƃ̋���")]
    [SerializeField] float _spawnMinDistance = 3;
    float _timer = 0;
    GameObject _player;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _enteredSpawnCT = _spawnCTs[GameManager.Instance.DreamLevel];
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _enteredSpawnCT)
        {
            Vector3 spawnPosRandom = new Vector3(Random.Range(-_spawnSize.x, _spawnSize.x), 0, Random.Range(-_spawnSize.z, _spawnSize.z));
            Vector3 spawnPos = this.transform.position - spawnPosRandom + new Vector3(0, _spawnY, 0);
            if (spawnPos.magnitude <= _spawnMinDistance)
            {
                spawnPos += (_player.transform.position - spawnPosRandom).normalized * _spawnMinDistance;
            }
            _spawnObj.transform.position = spawnPos;
            if (_spawnObj != null)
            Instantiate(_spawnObj);
            _timer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, _spawnSize * 2);
    }
}
