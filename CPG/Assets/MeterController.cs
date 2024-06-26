using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    public Image fillImage;        // Reference to the fill part of the bar
    [SerializeField] float fillDuration = 4.0f; // Duration to fill the bar

    void Start()
    {
        StartCoroutine(FillBar());
    }

    void Update()
    {

        if(fillImage.fillAmount == 0){
            StopAllCoroutines();  // Stop the current filling coroutine
            StartCoroutine(FillBar());
        }
    }

    public void pum(){
        StopAllCoroutines();  // Stop the current filling coroutine
        fillImage.fillAmount = 0;
    }

    IEnumerator FillBar()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            fillImage.fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);
            yield return null;
        }

        fillImage.fillAmount = 1f;
    }
}
