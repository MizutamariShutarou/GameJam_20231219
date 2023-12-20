using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyDestroyedTest : MonoBehaviour
{
    [SerializeField] float _fadeTime = 0.6f;
    Material _material;
    void Start()
    {
        _material = GetComponent<Material>();
        StartCoroutine(IFade());
    }
    IEnumerator IFade()
    {
        //animator‚Ì„ˆÚ‚Ìˆ—‚ğ‚±‚±‚É‘‚­
        _material.DOFade(0, _fadeTime);
        yield return new WaitForSeconds(_fadeTime);
        if (_material != null)
        {
            Destroy(_material);
            _material = null;
        }
        Destroy(this.gameObject);
    }
}
