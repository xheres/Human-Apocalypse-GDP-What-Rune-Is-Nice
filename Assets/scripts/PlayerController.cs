using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	
	float duration = 1.5f,
		  MAX_Y = 0.0f;
	Vector2 endPoint;
	bool flag = false;
	
	void Update () 
	{
		if (Input.GetMouseButton(0)) 
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
	}
}

