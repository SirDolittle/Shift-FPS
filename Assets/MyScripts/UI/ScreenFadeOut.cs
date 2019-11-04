using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFadeOut : MonoBehaviour
{

    public GameObject DamageUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }


   public IEnumerator DoFadeOut()
    {
        Debug.Log("FadeOutCalled");
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            canvasGroup.blocksRaycasts = true;

            yield return null;
        }
        yield return null;
        DamageUI.SetActive(false);
    }

}
