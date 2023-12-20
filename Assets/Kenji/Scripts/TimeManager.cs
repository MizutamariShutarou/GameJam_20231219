
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    private Text TimeText;

    /// <summary>true の時は一時停止とする</summary>
    bool _pauseFlg = false;

    public float TotalTime => totalTime;

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        TimeText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //　制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //　一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //　再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //　タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            TimeText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            Debug.Log("制限時間終了");
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            PauseResume();
        }
    }
    /// <summary>
    /// 一時停止・再開を切り替える
    /// </summary>
    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;

        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Pause または Resume を呼んでいる。
        // 本来は tag などで絞り込んだ方がよいでしょう。
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_pauseFlg)
            {
                i?.Pause();     
            }
            else
            {
                i?.Resume();   
            }
        }
    }
    //public void ReduceTimere()
    //{
    //    //　再設定
    //    minute = (int)totalTime / 60;
    //    seconds = totalTime - 60f;
    //}
}
