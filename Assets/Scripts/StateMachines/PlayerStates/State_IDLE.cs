using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_IDLE : State
{
    public Player m_Player;
    public Vector3 idleSize;

    public void Start()
    {
        m_Player = this.GetComponent<Player>();
    }

    public override void OnEnter()
    {

        Debug.Log("Idle entered");
    }
    public override void UpdateState()
    {
        this.transform.localScale = idleSize;
    }

    public override void OnExit()
    {

    }

    public override State CheckTransition()
    {
        return null;
    }
}
