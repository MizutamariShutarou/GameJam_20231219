using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = default;

    public static GameManager Instance => _instance;

    private bool _isActive = default;

    [SerializeField]
    private GameObject _player = default;

    [SerializeField]
    private Fade _fade = default;

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

    public void SetLevel()
    {
        _dreamLevel = UnityEngine.Random.Range(1, MaxLevel);
        Debug.Log(_dreamLevel);
    }

    public void FadeIn(Action action)
    {
        _fade.FadeIn(action);
    }

    public void FadeOut(Action action)
    {
        _fade.FadeOut(action);
    }

}
