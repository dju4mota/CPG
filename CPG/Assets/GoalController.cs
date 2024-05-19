using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInOut());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeInOut(){
        yield return StartCoroutine(Fade(0,0.5f,0.3f));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(Fade(0.5f,0,0.3f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeInOut());
    }

    IEnumerator Fade(float start, float end, float duration){
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed/duration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
