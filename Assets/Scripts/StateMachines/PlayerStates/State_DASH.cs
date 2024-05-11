using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_DASH : State
{
    public Player m_Player;
    public Vector3 dashSize;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;


    [HideInInspector]
    public Vector3 dashDirection;

    [HideInInspector]
    public float dashTimer;



    public void Start()
    {
        m_Player = this.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        dashTimer = dashDuration;
        m_Player.movement_speed = dashSpeed;
        this.transform.localScale = dashSize;
        Debug.Log("Dash entered");

        dashDirection.x = m_Player.player_input.left_stick.x;
        dashDirection.y = m_Player.player_input.left_stick.y;
        dashDirection.z = 0f;
    }
    public override void UpdateState()
    {
        m_Player.PlayerMovement(dashDirection);
        dashTimer -= Time.deltaTime;

        State transition = CheckTransition();
        if (transition != null)
        {
            m_Player.m_StateManager.ChangeState(transition);
        }
    }

    public override void OnExit()
    {
        m_Player.dashDelay = dashCooldown;
    }

    public override State CheckTransition()
    {
        if (dashTimer <= 0f)
        {
            return m_Player.idle;
        }
        return null;
    }
}