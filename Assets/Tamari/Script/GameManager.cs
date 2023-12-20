using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = default;

    public static GameManager Instance => _instance;

    [SerializeField]
    private GameObject _player = default;

    private PlayerManager _playerManager = default;

    public GameObject Player => _player;

    public PlayerManager PlayerManager => _playerManager;

     
    private int _dreamLevel;
    public int DreamLevel => _dreamLevel;

    [SerializeField]
    private int MaxLevel = 6; 

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<GameManager>();
            _playerManager = _player.GetComponent<PlayerManager>();
            _playerManager.Initialize();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _dreamLevel =  Random.Range(1, MaxLevel);
    }
}
