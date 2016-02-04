// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05FSM : MonoBehaviour 
{
    Boss05State nextState;

    DistanceController distanceController;

    bool bossSpawned = false;

    int moveIndex = 0;
    int attackIndex = 0;

    bool canFire; // Can the boss fire the attack?
    float[] cd = {};

    [SerializeField] float yPos = 6.5f;
    [SerializeField] Vector2[] wayPoints;
    [SerializeField] GameObject[] attackSet;

    public void ChangeState(Boss05State state)
    {
        nextState = state;
    }

    public bool getCanFire()
    {
        return canFire;
    }

    public void setCanFire(bool fire)
    {
        canFire = fire;
    }

    public void canFireCooldown()
    {
        Invoke("allowFire", cd[attackIndex]);
    }

    void allowFire()
    {
        canFire = true;
    }

    public int getMoveIndex()
    {
        return moveIndex;
    }
    public int getAttackIndex()
    {
        return attackIndex;
    }

    public void setMoveIndex(int index)
    {
        moveIndex = index;
    }

    public void setAttackIndex(int index)
    {
        attackIndex = index;
    }

    void Start()
    {
        // Set the next state to Spawn the Boss
        nextState = new Boss05StateSpawn(this);

        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
    }

    void Update()
    {
        // check if player is on boss stage
        if(distanceController.checkBossStage() && !bossSpawned)
        {
            nextState.Enter();
            bossSpawned = true;
        }
    }

    public float getYPos()
    {
        return yPos;
    }

    public Transform getTransform()
    {
        return transform;
    }

    public Vector2[] getWaypoints()
    {
        return wayPoints;
    }

    public GameObject getAttack()
    {
        return attackSet[attackIndex];
    }
}
