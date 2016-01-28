using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour 
{
    bool allowButton = false;

    FadeInOut fadeController;

    void Start()
    {
        fadeController = GameObject.Find("Fader").GetComponent<FadeInOut>();
    }

    public void SetAllowButton(bool set)
    {
        allowButton = set;
    }

    public void PlayButton()
    {
        if (allowButton)
        {
            FadeOut();
            Invoke("StartGame", 1.0f);
        }
    }

    public void OptionButton()
    {
        if (allowButton)
        {
            Debug.Log("Option");
            FadeOut();
            Invoke("FadeIn", 1.0f);
        }
    }

    public void CreditsButton()
    {
        if (allowButton)
        {
            Debug.Log("Credits");
            FadeOut();
            Invoke("FadeIn", 1.0f);
        }
    }

    void StartGame()
    {
        Application.LoadLevel(1);
    }

    void FadeOut()
    {
        allowButton = false;
        fadeController.setFadeDuration(2.0f);
        fadeController.StartCoroutine(fadeController.FadeOut());
    }

    void FadeIn()
    {
        allowButton = false;
        fadeController.setFadeDuration(1.0f);
        fadeController.StartCoroutine(fadeController.FadeIn());
        Invoke("EnableMenu", 0.5f);
    }

    void EnableMenu()
    {
        allowButton = true;
    }
}
