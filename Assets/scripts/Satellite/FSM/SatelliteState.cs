using UnityEngine;
using System.Collections;

public abstract class SatelliteState
{
    protected SatelliteFSM m_SatelliteFSM;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
