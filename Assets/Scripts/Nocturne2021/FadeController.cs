using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    public bool faded = true;

    public float time = 0.1f;

    public void Fade(CanvasGroup canvasGroup)
    {

        StartCoroutine(ActiveFade(canvasGroup, canvasGroup.alpha, faded ? 1 : 0));

        faded = !faded;
    }

    public IEnumerator ActiveFade(CanvasGroup canvasGroup, float start, float finish)
    {
        float counter = 0;

        while (counter < time)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, finish, counter / time);

            yield return new WaitForSeconds(1);
        }
    }
}
