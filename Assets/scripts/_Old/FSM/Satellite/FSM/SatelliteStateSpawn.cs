// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class SatelliteStateSpawn : SatelliteState
{
    bool hasEntered = false;

    [SerializeField] GameObject satellite;
    SatelliteState nextState;

    public SatelliteStateSpawn(SatelliteFSM _FSM)
    {
        m_SatelliteFSM = _FSM;
    }

    public override void Enter()
    {
        if (!hasEntered)
        {
            nextState = new SatelliteStateStartCooldown(m_SatelliteFSM);

            hasEntered = true;
        }

        Execute();
    }

    public override void Execute()
    {
        MonoBehaviour.Instantiate(satellite, new Vector3(0, m_SatelliteFSM.getYPos(), 0), Quaternion.identity);
        // Nothing to do after spawning, exit to next state
        Exit();
    }

    public override void Exit()
    {
        // Nothing to change, goes to next state
        m_SatelliteFSM.ChangeState(nextState);
    }
}
