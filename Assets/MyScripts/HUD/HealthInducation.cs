using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthInducation : MonoBehaviour
{
    // Start is called before the first frame update

    

    public void ShowHealthIndicator()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        StartCoroutine(DoFadeOut());
    }

    public IEnumerator DoFadeOut()
    {
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
