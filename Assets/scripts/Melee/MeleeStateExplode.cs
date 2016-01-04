// Lucas Lim
// P01
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateExplode : MeleeState
{
    bool explode = false;

    [SerializeField] GameObject explosionn;
    [SerializeField] float explosionDuration = 0.40f;
    GameObject explosion;
    MeleeState nextState;
    float explosionTimer;

    public MeleeStateExplode(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if (!explode)
        {
            explosionTimer = explosionDuration;
            nextState = new MeleeStateDeleteEntity(m_MeleeFSM);

            explosion = MonoBehaviour.Instantiate(explosionn, m_MeleeFSM.transform.position, Quaternion.identity) as GameObject;

            explode = true;
        }

        Execute();
    }

    public override void Execute()
    {
        // starts the timer for the explosion
        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0.40f)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        // destroy the explosion object
        MonoBehaviour.Destroy(explosionn);
        m_MeleeFSM.ChangeState(nextState);
    }
}
