using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

// DOTween 이라는 애니메이션 툴을 활용해 작성한 Popup창 기능을 설정하는 클래스
public class PopupHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
        gameObject.SetActive(false);
    }

    // 팝업창을 띄우는 메소드
    public void Show()
    {
        gameObject.SetActive(true);
        var seq = DOTween.Sequence();
        
        seq.Append(transform.DOScale(new Vector3(0.55f, 0.3f, 1f), 0.2f));
        seq.Append(transform.DOScale(new Vector3(0.5f, 0.25f, 1f), 0.1f));

        seq.Play();
    }
    
    // 팝업창을 숨기는 메소드
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
