using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	
	float duration = 1.5f,
		  MAX_Y = 4.0f,
          MIN_Y = -0.8f,
          MAX_X = 2.8f,
          MIN_X = -2.8f;

    Vector2 endPoint,
            pos;

	bool flag = false;
    bool allowMove = true;
	
	void Update () 
	{
		if (allowMove && Input.GetMouseButton(0)) 
		{ 
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) 
			{
				flag = true;
				endPoint = hit.point;
			}

			if (flag && !Mathf.Approximately (transform.position.magnitude, endPoint.magnitude))
				transform.position = Vector2.Lerp (transform.position, endPoint, 1 / (duration * (Vector2.Distance (gameObject.transform.position, endPoint))));
			else if(flag && Mathf.Approximately(transform.position.magnitude, endPoint.magnitude))
				flag = false;
		}

        pos= transform.position;
        pos.y = Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y);
        pos.x = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        transform.position = pos;
	}
}

