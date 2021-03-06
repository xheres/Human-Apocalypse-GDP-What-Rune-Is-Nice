﻿// Lucas Lim 
// P01 
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeFSM : MonoBehaviour {

    MeleeState currentState;

    public void ChangeState(MeleeState state)
    {
        currentState = state;
    }

    void Start()
    {
        currentState = new MeleeStateSpawn(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentState.Enter();
    }
}
