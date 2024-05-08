using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput player_input;
    public float movement_speed;
    private Renderer myRenderer;
    public PlayerSpec initial_spec;
    public PlayerSpec current_spec;
    public PlayerSpec secondary_spec;
    public PowerUpTypes.Types currentType = PowerUpTypes.Types.GREY;


    [Header("Player States")]
    public State idle;
    public State running;
    public State shooting;

    [HideInInspector]
    public StateManager m_StateManager;



    private float firingDelay = 0f;


    // Start is called before the first frame update

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        m_StateManager = GetComponent<StateManager>();

        //sets initial spec
        SetPlayerSpec(initial_spec);

        m_StateManager.ChangeState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        InputLoop();
        PlayerMovement();

        if (player_input.mouse_held)
        {
            if (firingDelay == 0f)
            {
                ShootBullet();
                m_StateManager.ChangeState(shooting);
            }
        }
        firingDelay = Mathf.Clamp(firingDelay - 0.5f, 0f, firingDelay);

        m_StateManager.UpdateStates();
    }

    public void InputLoop()
    {
        if (Input.GetMouseButton(0))
        {
            player_input.mouse_held = true;
        }
        else
        {
            player_input.mouse_held = false;
        }

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

        // Check buttons
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

        // if key is held
        if (Input.GetKey(KeyCode.J))
        {
            player_input.jump_hold = true;
        }
        else
        {
            player_input.jump_hold = false;
        }
        if (Input.GetKey(KeyCode.K))
        {
            player_input.attack_hold = true;
        }
        else
        {
            player_input.attack_hold = false;
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
        current_spec = spec;
    }

    public void ShootBullet()
    {
        Bullet spawnedBullet;
        spawnedBullet = Instantiate(current_spec.bullet, this.transform.position, Quaternion.identity).GetComponent<Bullet>();
        firingDelay = current_spec.fire_delay;


        Vector3 bulletVector = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 normalizedMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, bulletVector.z);
        bulletVector = normalizedMousePos - bulletVector;
        spawnedBullet.initialDirection = bulletVector.normalized;
        float angle = Mathf.Atan2(bulletVector.y, bulletVector.x) * Mathf.Rad2Deg;
        spawnedBullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //spawnedBullet.transform.LookAt(mouseWorldPos, Vector3.up);

    }
}
