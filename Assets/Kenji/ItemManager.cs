using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Tooltip("�{�^�����������Ƃ��ɂȂ炷���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>�񕜗�</summary>
    [SerializeField] int _recoverLife = 10;
    /// <summary>�Q�[�W��ω�������b��</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;
    /// <summary>Player�̃X�s�[�h�����l</summary>
    [SerializeField] float _speed = 1f;
    ///<summary>Player�̃X�s�[�h�㏸��</summary>
    [SerializeField] float _speedUp = 1.5f;
    /// <summary> </summary>
    private GameObject _buttonObjet = null;
    IEnumerator _enumerator = default(IEnumerator);

    /// <summary>���C�t�̌��ݒl</summary>
    int _life;
    /// <summary>���C�t�ϓ����l</summary>
    int _changeLife;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 1f;
    }
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
    //public void UseItem(string parameterType)
    //{
    //    GameManager.Instance.PlayerManager.ItemParamChangeActive(parameterType, _changeLife);
    //}

    //public void UseItem(string itemType)
    //{
    //    GameManager.Instance.PlayerManager.ItemParamChangeActive(itemType, _changeLife);
    //}
}
