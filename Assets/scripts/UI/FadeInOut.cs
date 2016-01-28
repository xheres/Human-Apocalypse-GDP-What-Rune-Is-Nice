using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour 
{
    [SerializeField] float fadeDuration = 1;

    float fadeTimeB = 0;
    float fadeTimeC = 0;

    Image img;
    Color black;
    Color clear;

    void Start()
    {
        img = GetComponent<Image>();
        black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        clear = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    public void setFadeDuration(float duration)
    {
        fadeDuration = duration;
    }

    public IEnumerator FadeOut()
    {
        while(fadeTimeB / fadeDuration < 1)
        {
            img.color = Color.Lerp(img.color, black, fadeTimeB/fadeDuration);
            fadeTimeB += Time.deltaTime;

            yield return null;
        }
        fadeTimeB = 0.0f;
        img.color = black;
    }

    public IEnumerator FadeIn()
    {
        while (fadeTimeC / fadeDuration < 1)
        {
            img.color = Color.Lerp(img.color, clear, fadeTimeC/fadeDuration);
            fadeTimeC += Time.deltaTime;

            yield return null;
        }
        fadeTimeC = 0.0f;
        img.color = clear;
    }
}
