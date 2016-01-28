using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour 
{
    FadeInOut fadeController;
    ButtonHandler buttonHandler;

	// Use this for initialization
	void Start () 
    {
        fadeController = GameObject.Find("Fader").GetComponent<FadeInOut>();
        buttonHandler = GameObject.Find("ButtonHandler").GetComponent<ButtonHandler>();

        Invoke("MenuStart", 0.25f);
	}

    void EnableMenu()
    {
        buttonHandler.SetAllowButton(true);
    }

    public void MenuStart()
    {
        buttonHandler.SetAllowButton(false);
        fadeController.setFadeDuration(1.0f);
        fadeController.StartCoroutine(fadeController.FadeIn());
        Invoke("EnableMenu", 0.5f);
    }

    public void MenuChange()
    {
        buttonHandler.SetAllowButton(false);
        fadeController.setFadeDuration(1f);
        fadeController.StartCoroutine(fadeController.FadeOut());
    }
}
