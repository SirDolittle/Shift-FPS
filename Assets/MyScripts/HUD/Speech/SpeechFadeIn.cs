using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechFadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    public void fadein()
    {
        StartCoroutine(DoFade());
    }
    public void fadeout()
    {
        StartCoroutine(DoFadeout());
    }

    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            canvasGroup.blocksRaycasts = true;

            yield return null;
        }
        yield return null;
    }

    IEnumerator DoFadeout()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            canvasGroup.blocksRaycasts = true;

            yield return null;
        }
        yield return null;


    }
}
