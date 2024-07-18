using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [HideInInspector]
    public PlayerFollower follower;
    public float rotationSpeed;
    public float smoothTime;
    public Vector3 currentVelocity;




    // Start is called before the first frame update
    void Start()
    {
        follower = GetComponentInChildren<PlayerFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        follower.TrackPlayer();
        InterpolateCamera();

    }

    public void InterpolateCamera()
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position, follower.transform.position, ref currentVelocity, smoothTime);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, follower.transform.rotation, rotationSpeed * Time.deltaTime);
    }
}
