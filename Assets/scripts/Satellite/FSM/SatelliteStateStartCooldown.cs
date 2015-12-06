using UnityEngine;
using System.Collections;

public class SatelliteStateStartCooldown : SatelliteState
{
    bool hasEntered = false;

    [SerializeField] float cooldown = 60.0f;

    SatelliteState nextState;

    Transform player;
    Transform myTransform;
    float playerPos;
    float cooldownTimer;

    public SatelliteStateStartCooldown(SatelliteFSM _FSM)
    {
        m_SatelliteFSM = _FSM;
    }

    public override void Enter()
    {
        if(!hasEntered)
        {
            myTransform = m_SatelliteFSM.transform;
            player = GameObject.Find("Player").transform;
            nextState = new SatelliteStateWarning(m_SatelliteFSM);
            cooldownTimer = cooldown;

            hasEntered = true;
        }

        Execute();
    }

    public override void Execute()
    {
        FollowPlayer();
        Cooldown();
    }

    public override void Exit()
    {
        m_SatelliteFSM.ChangeState(nextState);
    }

    void FollowPlayer()
    {
        playerPos = player.position.x;
        myTransform.position = new Vector2(playerPos, m_SatelliteFSM.getYPos());
    }

    void Cooldown()
    {
        cooldown -= Time.deltaTime;
        if (cooldown % 60 < 0)
        {
            // Once cooldown has reached 0, time to set up warning sign
            Exit();
        }
    }
}
