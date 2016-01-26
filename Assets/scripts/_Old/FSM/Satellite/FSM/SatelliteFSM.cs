// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class SatelliteFSM : MonoBehaviour 
{
    SatelliteState currentState;

    float yPos = 25.0f;

    public void ChangeState(SatelliteState state)
    {
        currentState = state;
    }

    void Start()
    {
        currentState = new SatelliteStateSpawn(this);
    }

    void Update()
    {
        // if player on boss stage (needs to run getter from another script)
            // change currentState to m_Standby

        currentState.Enter();
    }

    public float getYPos()
    {
        return yPos;
    }
}
