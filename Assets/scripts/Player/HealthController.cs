using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	// Use this for initialization
    Animator anim;
	void Start () {
	 anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void ReduceHealth ()
    {
        int h = anim.GetInteger("Health");
        h = h -1;
        anim.SetInteger("Health",h);
        Debug.Log(h);
   
    }
}
