using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    /* �l */
    string[] rankNames = { "1st", "2nd", "3rd" };        // �����L���O��
    const int rankCnt = SaveData.rankCnt;                 // �����L���O��

    /* �R���|�[�l���g�擾�p */
    Text[] rankTexts = new Text[rankCnt];              // �����L���O�̃e�L�X�g
    SaveData data;                                       // �Q�Ƃ���Z�[�u�f�[�^

    void Start()
    {
        data = GetComponent<DataManager>().data;            // �Z�[�u�f�[�^��DataManager����Q��

        for (int i = 0; i < rankCnt; i++)
        {
            Transform rankChilds = GameObject.Find("RankTexts").transform.GetChild(i);      // �q�I�u�W�F�N�g�擾
            rankTexts[i] = rankChilds.GetComponent<Text>();                                 // �q�I�u�W�F�N�g�̃R���|�[�l���g�擾
        }
    }
    void FixedUpdate()
    {
        DispRank();
    }

    // �����L���O�\��
    void DispRank()
    {
        for (int i = 0; i < rankCnt; i++)
        {
            rankTexts[i].text = (rankNames[i] + " : " + data.rank[i]);
        }
    }

    // �����L���O�ۑ�
    public void SetRank()
    {
        InputField inpFld = GameObject.Find("InputField").GetComponent<InputField>();
        int score = int.Parse(inpFld.text);     // string -> int

        // �X�R�A�������L���O���̒l�����傫���Ƃ��͓���ւ�
        for (int i = 0; i < rankCnt; i++)
        {
            if (score > data.rank[i])
            {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }
    }
    // �����N�f�[�^�̍폜
    public void DelRank()
    {
        for (int i = 0; i < rankCnt; i++)
        {
            data.rank[i] = 0;
        }
    }
}
