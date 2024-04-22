using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 size;
    [HideInInspector]
    public Vector3 initialDirection;
    public float speed;
    public float lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        lifeSpan -= 1f * Time.deltaTime;
        if (lifeSpan <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Move()
    {
        this.transform.Translate(initialDirection * (speed * Time.deltaTime));
    }
}
