using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Collactable : MonoBehaviour
{

    void Start()
    {
        StarAnimation();
        
    }

    private void StarAnimation()
    {
        transform.DOMoveY(transform.position.y+1, .4f)
            .SetLoops(-1, LoopType.Yoyo); //-1 sonsuz loop demek 2 yazsan 2 kere zıplar
        
        transform.DORotate(Vector3.up * 90, .5f)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }                                                           
}
