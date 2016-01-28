﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    FadeInOut fadeController;
    Spawner_Script spawnController;
    DistanceController distanceController;

    void Start()
    {
        spawnController = GameObject.Find("Spawner").GetComponent<Spawner_Script>();
        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
        fadeController = GameObject.Find("Fader").GetComponent<FadeInOut>();

        Invoke("stageStart", 0.25f);
    }

    void startGame()
    {
        distanceController.enabled = true;
        spawnController.enabled = true;
    }

    public void stageStart()
    {
        // - Show Stage #
        fadeController.setFadeDuration(20.0f);
        fadeController.StartCoroutine(fadeController.FadeIn());
        Invoke("startGame", 3.0f);
    }

    public void StageEnd()
    {
        fadeController.setFadeDuration(30.0f);
        fadeController.StartCoroutine(fadeController.FadeOut());
    }
}
