using UnityEngine;
 
public class ButtonController : MonoBehaviour
{
    private GameObject _targetObjet = null;
 
    void Start()
    {
        string _targetObjectName = gameObject.name.Replace("_Btn", "");
        _targetObjet = GameObject.Find(_targetObjectName).gameObject;
    }
 
    public void OnButton()
    {
        if (_targetObjet.activeSelf)
        {
            _targetObjet.SetActive(false);
        }
        else
        {
            _targetObjet.SetActive(true);
        }
    }
}