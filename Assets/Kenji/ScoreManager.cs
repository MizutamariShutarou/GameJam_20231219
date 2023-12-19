using System.Collections;
using System.Collections.Generic;
using DG.Tweening;  // DOTween を使うため
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>スコアをカウントアップさせる秒数</summary>
    [SerializeField] float _scoreChangeInterval = 0.5f;
    Text _scoreText = default;
    /// <summary>カンストするスコア</summary>
    int _maxScore = 99999999;
    int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }
    /// <summary>
    /// 得点を加算し、表示を更新する
    /// </summary>
    /// <param name="score">追加する点数</param>
    public void AddScore(int score)
    {
        int oldScore = _score;//追加以前のスコア
        _score = Mathf.Min(_score + score, _maxScore);  // _maxScore でカンストさせる
        if (oldScore != _maxScore)
        {
            //このように書いてもよい
            DOTween.To(() => oldScore, x =>
            {
                oldScore = x;
                _scoreText.text = oldScore.ToString("00000000");
            }, _score, _scoreChangeInterval).OnComplete(() => _scoreText.text = _score.ToString("00000000"));
            Debug.Log("得点更新完了");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
