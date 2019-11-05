using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndication : MonoBehaviour
{

    private void Awake()
    {

    }


    public void ShowDamageIndicator()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        StartCoroutine(DoFadeOut());
    }

    public IEnumerator DoFadeOut()
    {
        Debug.Log("FadeOutCalled");
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 3;
            canvasGroup.blocksRaycasts = true;

            yield return null;
        }
        yield return null;
     }

}
