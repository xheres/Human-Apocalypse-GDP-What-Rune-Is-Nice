using UnityEngine;
using System.Collections;

public class SatelliteFSM : MonoBehaviour {

    public enum eSatelliteState
    {
        Spawn,
        StartCooldown,
        CreateMuzzle,
        Warning,
        Fire,
        Standby
    }

    SatelliteState m_Spawn;
    SatelliteState m_StartCooldown;
    SatelliteState CreateMuzzle;
    SatelliteState Warning;
    SatelliteState Fire;
    SatelliteState Standby;

    void Start ()
    {
        //m_StateSpawn = new BossStateSpawn(this);
    }
}
