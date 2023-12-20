using DG.Tweening;
using UnityEngine;

public class EnemyDestroyedTest : MonoBehaviour
{
    [SerializeField] float _fadeTime = 0.6f;
    MeshRenderer _meshRen;
    void Start()
    {
        _meshRen = GetComponent<MeshRenderer>();
        _meshRen.material.DOFade(0, _fadeTime).OnComplete(Kill);
    }
    void Kill()
    {
        //animator‚Ì„ˆÚ‚Ìˆ—‚ğ‚±‚±‚É‘‚­
        if (_meshRen != null)
        {
            Destroy(_meshRen);
            _meshRen = null;
        }
        Destroy(this.gameObject);
    }
}
