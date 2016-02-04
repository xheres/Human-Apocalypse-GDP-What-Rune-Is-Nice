using UnityEngine;
using System.Collections;

public interface IBossState 
{
    void UpdateState();

    void OnTriggerEnter(Collider other);

    // Declaring States
    void ToSpawnState();

    void ToMoveState();

    void ToAttackState();

    void ToRetreatState();
	
}
