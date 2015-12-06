using UnityEngine;
using System.Collections;

public class SatelliteStateStandby: SatelliteState
{
    bool hasEntered = false;

    SatelliteState nextState;

    public SatelliteStateStandby(SatelliteFSM _FSM)
    {
        m_SatelliteFSM = _FSM;
    }

    public override void Enter()
    {
        if(!hasEntered)
        {
            nextState = new SatelliteStateStartCooldown(m_SatelliteFSM);
            hasEntered = true;
        }

        Execute();
    }

    public override void Execute()
    {
        // Satellite does nothing until the player has left the boss stage
        // if ( run boss stage getter from m_SatelliteFSM )
            // if its false, Exit()
    }

    public override void Exit()
    {
        m_SatelliteFSM.ChangeState(nextState);
    }
}
