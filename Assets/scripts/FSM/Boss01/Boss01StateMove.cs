//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class Boss01StateMove : Boss01State {
    Transform Boss;
    float speed = 1.0f;
    bool hasEntered = false;
    int point = 1;
    bool doneMoving = false;
    bool right = true;
    public Boss01StateMove(Boss01FSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        Boss = GameObject.Find("Boss01").GetComponent<Transform>();
        Execute();
    }

    public override void Execute()
    {
        if (doneMoving == false)
        {
            Move();
        }
        if (Boss.transform.position.x >= 1.45 && Boss.transform.position.x <= 1.55)
        {
            point = 3;
            doneMoving = true;
        }
        if (Boss.transform.position.x >= -0.05 && Boss.transform.position.x <= 0.05)
        {
            point = 2;
            doneMoving = true;
        }
        if (Boss.transform.position.x <= -1.45 && Boss.transform.position.x >= -1.55)
        {

            point = 1;
            doneMoving = true;
        }

        if (doneMoving == true)
        {
            Exit();
        }

    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }

    void Move()
    {
        if (point == 2 && right == true)
        {
            Boss.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (point == 2 && right == false)
        {
            Boss.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (point == 3 && right == true)
        {
            Boss.transform.Translate(Vector2.left * speed * Time.deltaTime);
            right = false;
        }
        if (point == 3 && right == false)
        {
            Boss.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (point == 1 && right == true)
        {
            Boss.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (point == 1 && right == false)
        {
            Boss.transform.Translate(Vector2.right * speed * Time.deltaTime);
            right = true;
        }
    }
}
