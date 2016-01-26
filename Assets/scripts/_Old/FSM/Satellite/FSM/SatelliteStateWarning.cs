// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class SatelliteStateWarning : SatelliteState
{
    bool hasEntered = false;

    SatelliteState nextState;

    [SerializeField] GameObject warningSign;
    [SerializeField] float warningYPos = 8.5f;
    [SerializeField] float warningDuration = 1.5f;
    GameObject iWarningSign;
    float myTransformXPos;
    float warningDurationTimer;

    public SatelliteStateWarning(SatelliteFSM _FSM)
    {
        m_SatelliteFSM = _FSM;
    }

    public override void Enter()
    {
        if (!hasEntered)
        {
            nextState = new SatelliteStateFire(m_SatelliteFSM);
            myTransformXPos = m_SatelliteFSM.transform.position.x;
            warningDurationTimer = warningDuration;
            //Create warning sign
            iWarningSign = MonoBehaviour.Instantiate(warningSign, new Vector3(myTransformXPos, warningYPos, 0), Quaternion.identity) as GameObject;
        }

        Execute();
    }

    public override void Execute()
    {       
        warningDurationTimer -= Time.deltaTime;
        // Warning Duration time out, change state
        if (warningDurationTimer <= 0)  
        {
            Exit(); 
        }
    }

    public override void Exit()
    {
        MonoBehaviour.Destroy(iWarningSign);
        m_SatelliteFSM.ChangeState(nextState);
    }
}
