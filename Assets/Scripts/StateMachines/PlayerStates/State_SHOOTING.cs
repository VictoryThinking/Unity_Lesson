using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State_SHOOTING : State
{
    public Player m_Player;
    public Vector3 shootingSize;
    public float fire_Cooldown;
    public float timer;

    public void Start()
    {
        m_Player = this.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        timer = fire_Cooldown;
        Debug.Log("Shooting entered");
    }
    public override void UpdateState()
    {
        this.transform.localScale = shootingSize;
        timer -= Time.deltaTime;

        State transition = CheckTransition();
        if (transition != null)
        {
            m_Player.m_StateManager.ChangeState(transition);
        }
    }

    public override void OnExit()
    {

    }

    public override State CheckTransition()
    {
        if (timer <= 0f)
        {
            return m_Player.idle;
        }
        return null;
    }
}
