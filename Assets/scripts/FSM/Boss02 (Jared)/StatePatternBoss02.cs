using UnityEngine;
using System.Collections;

public class StatePatternBoss02 : MonoBehaviour 
{
    public GameObject boss;
    public float movementSpeed;
    public GameObject[] muzzleSelect; // Stores all 5 boss attacks into this array
    public bool dirRight = true;
    public float speed = 1.0f;
    public int counter = 0;
    public bool spawned = false;
 

    [HideInInspector]

    public IBossState currentState;
    public Boss02SpawnState spawnState;
    public Boss02MoveState moveState;
    public Boss02AttackState attackState;
    public Boss02RetreatState retreatState;

    private void Awake()
    {
        spawnState = new Boss02SpawnState(this);
        moveState = new Boss02MoveState(this);
        attackState = new Boss02AttackState(this);
        retreatState = new Boss02RetreatState(this);
    }



	// Use this for initialization
	void Start () 
    {
        currentState = spawnState;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentState.UpdateState();
	}

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
