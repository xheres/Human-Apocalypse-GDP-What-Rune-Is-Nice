using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    GameObject BG;
    GameObject retry;
    GameObject main;
    GameObject gameover;
 
	// Use this for initialization
    void Awake()
    {
        BG = GameObject.Find("GameOver_BG");
        retry = GameObject.Find("retry");
        main = GameObject.Find("main menu");
        gameover = GameObject.Find("gameover");

        BG.SetActive(false);
        retry.SetActive(false);
        main.SetActive(false);
        gameover.SetActive(false);
    }
	void Start () 
    {
      
        
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void showGameOver()
    {
        BG.SetActive(true);
        retry.SetActive(true);
        main.SetActive(true);
        gameover.SetActive(true);
    }
}
