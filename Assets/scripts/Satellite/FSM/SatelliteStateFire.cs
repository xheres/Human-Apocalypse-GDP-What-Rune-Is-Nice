using UnityEngine;
using System.Collections;

public class SatelliteStateFire : SatelliteState
{
    bool hasEntered = false;

    SatelliteState nextState;

    [SerializeField] GameObject laser;
    [SerializeField] float laserDuration = 0.75f;
    GameObject iLaser;
    float laserDurationTimer;

    public SatelliteStateFire(SatelliteFSM _FSM)
    {
        m_SatelliteFSM = _FSM;
    }

    public override void Enter()
    {
        if(!hasEntered)
        {
            laserDurationTimer = laserDuration;
            nextState = new SatelliteStateStartCooldown(m_SatelliteFSM);
            iLaser = MonoBehaviour.Instantiate(laser, m_SatelliteFSM.transform.position, Quaternion.identity) as GameObject;
            hasEntered = true;
        }

        Execute();
    }

    public override void Execute()
    {
        laserDurationTimer -= Time.deltaTime;
        // Warning Duration time out, change state
        if (laserDurationTimer <= 0)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        m_SatelliteFSM.ChangeState(nextState);
    }
}
