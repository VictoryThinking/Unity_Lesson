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
    public float moveSpeed;

    public void Start()
    {
        m_Player = this.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        m_Player.movement_speed = moveSpeed;
        timer = fire_Cooldown;
        Debug.Log("Shooting entered");
    }
    public override void UpdateState()
    {
        Vector3 movement_vector;
        movement_vector.x = m_Player.player_input.left_stick.x;
        movement_vector.y = m_Player.player_input.left_stick.y;
        movement_vector.z = 0f;
        m_Player.PlayerMovement(movement_vector);
        m_Player.CheckShoot();
        m_Player.CheckDash();
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
