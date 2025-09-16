using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random; 

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;
    private Vector3 originalPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        originalPos = transform.localPosition;
        
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
