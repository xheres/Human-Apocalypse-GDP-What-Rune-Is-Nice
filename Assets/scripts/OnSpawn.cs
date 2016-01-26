using UnityEngine;
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
        maxY = new Vector2(transform.position.x, enemyProp.getSpawnedYPos());
    }

	void Update () 
    {
        if(!hasSpawned)
            transform.position = Vector3.Lerp(transform.position, maxY, lerpRate * Time.deltaTime);

        if (transform.position.y <= enemyProp.getSpawnedYPos() + 0.01f)
            hasSpawned = true;
	}
}
