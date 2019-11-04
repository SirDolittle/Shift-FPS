using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public GameObject HUD;
   
    public void fade()
    {
        StartCoroutine(DoFade());
    }

   IEnumerator DoFade ()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            while (canvasGroup.alpha < 1) 
        {
            HUD.SetActive(false);
            canvasGroup.alpha += Time.deltaTime / 2;
            canvasGroup.blocksRaycasts = true;

            yield return null;
        }
        yield return null;
    }

}
