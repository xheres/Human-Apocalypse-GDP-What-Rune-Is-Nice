using UnityEngine;
using System.Collections;

public class MeleeFSM : MonoBehaviour {


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
	
	}
}
