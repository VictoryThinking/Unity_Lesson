using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput player_input;
    public float movement_speed;
    private Renderer myRenderer;
    public PlayerSpec initial_spec;
    public PlayerSpec attack_spec;
    public PowerUpTypes.Types currentType = PowerUpTypes.Types.GREY;

    // Start is called before the first frame update

    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        //sets initial spec
        SetPlayerSpec(initial_spec);

    }

    // Update is called once per frame
    void Update()
    {
        InputLoop();
        PlayerMovement();

        // placeholder test
        // changes player values based on spec
        if (player_input.attack_pressed)
        {
            SetPlayerSpec(attack_spec);

        }
        if (player_input.jump_pressed)
        {
            SetPlayerSpec(initial_spec);

        }
    }

    public void InputLoop()
    {
        //check Y axis
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            player_input.left_stick.y = 0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            player_input.left_stick.y = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player_input.left_stick.y = -1f;
        }

        //Check X axis
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            player_input.left_stick.x = 0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player_input.left_stick.x = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player_input.left_stick.x = -1f;
        }

        //Check buttons
        if (Input.GetKeyDown(KeyCode.J))
        {
            player_input.jump_pressed = true;
        }
        else
        {
            player_input.jump_pressed = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            player_input.attack_pressed = true;
        }
        else
        {
            player_input.attack_pressed = false;
        }
    }

    //Formula to move player in 2D
    public void PlayerMovement()
    {
        Vector3 movement_vector;
        movement_vector.x = movement_speed * player_input.left_stick.x;
        movement_vector.y = movement_speed * player_input.left_stick.y;
        movement_vector.z = 0f;
        this.transform.Translate(movement_vector * Time.deltaTime, Space.Self);
    }

    public void SetPlayerSpec(PlayerSpec spec)
    {
        myRenderer.material.color = spec.player_color;
        this.transform.localScale = spec.player_scale;
        movement_speed = spec.player_speed;
    }
}
