using UnityEngine;
using System.Collections;

public class Despawn : MonoBehaviour 
{
    DistanceController distanceController;
    EnemyProperties properties;
    Transform myTransform;
    Vector2 despawnVector;

    float lerpRate = 1f;
    bool isDespawning = false;

    void Start()
    {
        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
        properties = GetComponent<EnemyProperties>();
        myTransform = transform;
        despawnVector = new Vector2(myTransform.position.x, 15);
    }

    void Update()
    {
        if ( (distanceController.checkBossStage()) || (properties.getAmmo() <= 0 && properties.getAmmo() != -99) )
        {
            Invoke("Remove", 1.0f);
            if (!isDespawning)
                isDespawning = true;
        }

        if (myTransform.position.y >= 14 && isDespawning)
            Destroy(gameObject);
    }

    void Remove()
    {
        properties.SetAmmo(0);
        myTransform.position = Vector2.Lerp(myTransform.position, despawnVector, lerpRate * Time.deltaTime);
    }
}
