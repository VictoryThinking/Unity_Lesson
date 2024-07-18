using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform playerTransform;
    public float height;
    public float angleDamp;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TrackPlayer()
    {
        Vector3 newPosition;
        newPosition.x = playerTransform.position.x;
        newPosition.y = playerTransform.position.y - angleDamp;
        newPosition.z = playerTransform.position.z - height;

        this.transform.position = newPosition;
        this.transform.LookAt(playerTransform);

    }
}
