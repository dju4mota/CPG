using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    public Image fillImage;        // Reference to the fill part of the bar
    [SerializeField] float fillDuration = 4.0f; // Duration to fill the bar

    private bool isFilling = false;  // Flag to check if the bar is currently filling

    void Start()
    {
        StartCoroutine(FillBar());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && fillImage.fillAmount == 1)
        {
            StopAllCoroutines();  // Stop the current filling coroutine
            fillImage.fillAmount = 0;
        }
        if(fillImage.fillAmount == 0){
            StopAllCoroutines();  // Stop the current filling coroutine
            StartCoroutine(FillBar());
        }
    }

    IEnumerator FillBar()
    {
        isFilling = true;
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            fillImage.fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);
            yield return null;
        }

        fillImage.fillAmount = 1f;
        isFilling = false;
    }
}
