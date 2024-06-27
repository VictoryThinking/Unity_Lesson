using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float health;
    public float turnSpeed;
    public Transform myTransform;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        playerTransform = GameObject.Find("PlayerDefault").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        myTransform.LookAt(playerTransform);
    }
}
