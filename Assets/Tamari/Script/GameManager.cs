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
            DontDestroyOnLoad(gameObject);
        }
    }
}
