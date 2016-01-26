using UnityEngine;
using System.Collections;

public class PatternA_movement : MonoBehaviour 
{
    [SerializeField] float speed = 1;
    [SerializeField] float min;
    [SerializeField] float max;

    Vector3 newPos;
    bool pauseFlag = false;

	void Update () 
    {
        newPos = new Vector3(Time.deltaTime * speed, 0, 0);

	    if(transform.position.x < min)
        {
            speed = -speed;
            transform.position = new Vector3(min + 0.2f, transform.position.y, 0f);
        }
        if(transform.position.x > max)
        {
            speed = -speed;
            transform.position = new Vector3(max - 0.2f, transform.position.y, 0f);
        }

        transform.Translate(newPos);
	}
}
