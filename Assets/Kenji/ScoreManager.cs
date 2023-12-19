using System.Collections;
using System.Collections.Generic;
using DG.Tweening;  // DOTween ���g������
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>�X�R�A���J�E���g�A�b�v������b��</summary>
    [SerializeField] float _scoreChangeInterval = 0.5f;
    Text _scoreText = default;
    /// <summary>�J���X�g����X�R�A</summary>
    int _maxScore = 99999999;
    int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
    }
    /// <summary>
    /// ���_�����Z���A�\�����X�V����
    /// </summary>
    /// <param name="score">�ǉ�����_��</param>
    public void AddScore(int score)
    {
        int oldScore = _score;//�ǉ��ȑO�̃X�R�A
        _score = Mathf.Min(_score + score, _maxScore);  // _maxScore �ŃJ���X�g������
        if (oldScore != _maxScore)
        {
            //���̂悤�ɏ����Ă��悢
            DOTween.To(() => oldScore, x =>
            {
                oldScore = x;
                _scoreText.text = oldScore.ToString("00000000");
            }, _score, _scoreChangeInterval).OnComplete(() => _scoreText.text = _score.ToString("00000000"));
            Debug.Log("���_�X�V����");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
