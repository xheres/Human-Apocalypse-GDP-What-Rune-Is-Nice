using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour
{
    FadeInOut fader;

    void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<FadeInOut>();

        StartCoroutine(fader.FadeIn());
    }

    public void setFadeDuration(float duration)
    {
        fader.setFadeDuration(duration);
    }

    public void FadeIn()
    {
        StartCoroutine(fader.FadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(fader.FadeOut());
    }
}
