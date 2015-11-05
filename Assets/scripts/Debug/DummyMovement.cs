using UnityEngine;
using System.Collections;

public class DummyMovement : MonoBehaviour 
{
    float speed = 0.05f;
    void Update()
    {
        if (transform.position.x >= 4.3)
            speed = -speed;
        else if (transform.position.x <= -4.3)
            speed = -speed;
        transform.Translate(new Vector3(speed, 0f, 0f));
    }
}
