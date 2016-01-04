﻿using UnityEngine;
using System.Collections;

public class OnSpawn : MonoBehaviour 
{
    private EnemyProperties enemyProp;
    private Transform myTransform;
    private float lerpRate = 2f;
    private Vector2 maxY;

    bool hasSpawned = false;
	
    void Start()
    {
        enemyProp = GetComponent<EnemyProperties>();
        myTransform = transform;
        maxY = new Vector2(0, enemyProp.getSpawnedYPos());
    }

	void Update () 
    {
        if(myTransform.position.y != maxY.y && !hasSpawned)
            transform.position = Vector3.Lerp(myTransform.position, maxY, lerpRate * Time.deltaTime);

        if (myTransform.position.y <= 6.6)
            hasSpawned = true;
	}
}
