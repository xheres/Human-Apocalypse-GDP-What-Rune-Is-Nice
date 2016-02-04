using UnityEngine;
using System.Collections;

public class GameOverButtonHandler : MonoBehaviour {

    bool allowButton = false;

    FadeInOut fadeController;
	// Use this for initialization
	void Start () {
        fadeController = GameObject.Find("Fader").GetComponent<FadeInOut>();
	}
	

    public void SetAllowButton(bool set)
    {
        allowButton = set;
    }

    public void RetryButton()
    {
        if (allowButton)
        {
            FadeOut();
            Application.LoadLevel(1);
        }
    }

    public void MainMenuButton()
    {
        if (allowButton)
        {
            Debug.Log("Option");
            FadeOut();
            Application.LoadLevel(0);
        }
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
