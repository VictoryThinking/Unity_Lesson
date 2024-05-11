using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_IDLE : State
{
    public Player m_Player;
    public Vector3 idleSize;
    public float moveSpeed;

    public void Start()
    {
        m_Player = this.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        m_Player.movement_speed = moveSpeed;
        this.transform.localScale = idleSize;
        Debug.Log("Idle entered");
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
    }

    public override void OnExit()
    {

    }

    public override State CheckTransition()
    {
        return null;
    }
}
