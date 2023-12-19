using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Tooltip("ボタンを押したときにならす効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>回復量</summary>
    [SerializeField] float _recoverLife = 10;
    /// <summary>ゲージを変化させる秒数</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;
    ///<summary>Playerのスピード上昇率</summary>
    [SerializeField] float _speedUp = 1.5f;
    ///<summary>Playerの攻撃力上昇率</summary>
    [SerializeField] float _attackUp = 2f;
    /// <summary> </summary>
    private GameObject _buttonObjet = null;
    IEnumerator _enumerator = default(IEnumerator);

    /// <summary>ライフの現在値</summary>
    int _life;

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
    public void UseItem(string itemType)
    {
        var value = 0f;
        if(itemType == ParameterType.Hp.ToString())
        {
            value = _recoverLife;
        }
        else if(itemType == ParameterType.Attack.ToString())
        {
            value = _attackUp;
        }
        else if(itemType == ParameterType.Speed.ToString())
        {
            value = _speedUp;
        }

        GameManager.Instance.PlayerManager.ItemParamChangeActive(itemType, value);
    }
}
