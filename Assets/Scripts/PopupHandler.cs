using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        var seq = DOTween.Sequence();
        
        seq.Append(transform.DOScale(new Vector3(0.55f, 0.3f, 1f), 0.2f));
        seq.Append(transform.DOScale(new Vector3(0.5f, 0.25f, 1f), 0.1f));

        seq.Play();
    }
    
    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(new Vector3(0.55f, 0.3f, 1f), 0.2f));
        seq.Append(transform.DOScale(new Vector3(0.5f, 0.25f, 1f), 0.1f));
        
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
