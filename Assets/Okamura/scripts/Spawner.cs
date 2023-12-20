using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("エネミーの生成秒数の一覧")]
    [SerializeField] float[] _spawnCTs = { 7, 6, 5, 4, 3, 2 };
    [Tooltip("現在のエネミーの生成秒数")]
    [SerializeField, ReadOnly] float _enteredSpawnCT = 4;
    [Tooltip("生成するエネミー")]
    [SerializeField] GameObject _spawnObj;
    [Tooltip("生成するエネミーのY座標")]
    [SerializeField] float _spawnY = 1;
    [Tooltip("エネミーを生成する範囲")]
    [SerializeField] Vector3 _spawnSize = new Vector3(5, 5, 5);
    [Tooltip("エネミーが生成されないプレイヤーとの距離")]
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
