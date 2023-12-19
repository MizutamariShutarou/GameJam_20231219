using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Tooltip("ボタンを押したときにならす効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>回復量</summary>
    [SerializeField] int _recoverLife = 10;
    /// <summary>ゲージを変化させる秒数</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;
    /// <summary>Playerのスピード初期値</summary>
    [SerializeField] float _speed = 1f;
    ///<summary>Playerのスピード上昇率</summary>
    [SerializeField] float _speedUp = 1.5f;
    /// <summary> </summary>
    private GameObject _buttonObjet = null;
    IEnumerator _enumerator = default(IEnumerator);

    /// <summary>ライフの現在値</summary>
    int _life;
    /// <summary>ライフ変動数値</summary>
    int _changeLife;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 1f;
    }
    /// <summary>
    /// ゲージを減らす
    /// </summary>
    /// <param name="value">増減させる量（割合）</param>
    public void Change(float value)
    {
        ChangeValue(_slider.value + value);
    }

    
    void ChangeValue(float value)
    {
        _slider.value = value;
    }
    //public void UseItem(string parameterType)
    //{
    //    GameManager.Instance.PlayerManager.ItemParamChangeActive(parameterType, _changeLife);
    //}

    //public void UseItem(string itemType)
    //{
    //    GameManager.Instance.PlayerManager.ItemParamChangeActive(itemType, _changeLife);
    //}
}
