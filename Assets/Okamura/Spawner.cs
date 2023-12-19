using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float[] _spawnCTs = { 2, 3, 4, 5 };
    [SerializeField, ReadOnly] float _enteredSpawnCT;
    [SerializeField] GameObject _spawnObj;
    float timer = 0;
    void Start()
    {
        _enteredSpawnCT = _spawnCTs[UnityEngine.Random.Range(0, _spawnCTs.Length - 1)];
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > _enteredSpawnCT)
        {
            _spawnObj.transform.position = this.transform.position;
            if(_spawnObj != null)
            Instantiate(_spawnObj);
            timer = 0;
        }
    }
}
