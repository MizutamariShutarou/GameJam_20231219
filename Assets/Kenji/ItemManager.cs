using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Tooltip("�{�^�����������Ƃ��ɂȂ炷���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>�񕜗�</summary>
    [SerializeField] float _recoverLife = 10;
    /// <summary>�Q�[�W��ω�������b��</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;
    ///<summary>Player�̃X�s�[�h�㏸��</summary>
    [SerializeField] float _speedUp = 1.5f;
    ///<summary>Player�̍U���͏㏸��</summary>
    [SerializeField] float _attackUp = 2f;
    /// <summary> </summary>
    private GameObject _buttonObjet = null;
    IEnumerator _enumerator = default(IEnumerator);

    /// <summary>���C�t�̌��ݒl</summary>
    int _life;

    /// <summary>
    /// �Q�[�W�����炷
    /// </summary>
    /// <param name="value">����������ʁi�����j</param>
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
