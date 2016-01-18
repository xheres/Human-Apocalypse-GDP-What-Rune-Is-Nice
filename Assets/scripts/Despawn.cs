using UnityEngine;
using System.Collections;

public class Despawn : MonoBehaviour 
{
    EnemyProperties properties;
    Transform myTransform;
    Vector2 despawnVector;

    float lerpRate = 1f;
    bool isDespawning = false;

    void Start()
    {
        properties = GetComponent<EnemyProperties>();
        myTransform = transform;
        despawnVector = new Vector2(myTransform.position.x, 12);
    }

    void Update()
    {
        if (properties.getAmmo() <= 0 && properties.getAmmo() != -99)
        {
            Invoke("Remove", 1);
            if (!isDespawning)
                isDespawning = true;
        }

        if (myTransform.position.y >= 10 && isDespawning)
            Destroy(gameObject);
    }

    void Remove()
    {
        myTransform.position = Vector2.Lerp(myTransform.position, despawnVector, lerpRate * Time.deltaTime);
    }
}
