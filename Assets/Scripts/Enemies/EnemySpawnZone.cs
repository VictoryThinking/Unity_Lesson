using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnZone : MonoBehaviour
{
    public Vector3 minimumBounds;
    public Vector3 maximumBounds;
    public GameObject enemy;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        minimumBounds.x = -this.transform.localScale.x * 0.5f;
        maximumBounds.x = this.transform.localScale.x * 0.5f;
        minimumBounds.y = -this.transform.localScale.y * 0.5f;
        maximumBounds.y = this.transform.localScale.y * 0.5f;

        minimumBounds += this.transform.position;
        maximumBounds += this.transform.position;

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 position;
            position.x = UnityEngine.Random.Range(minimumBounds.x, maximumBounds.x);
            position.y = UnityEngine.Random.Range(minimumBounds.y, maximumBounds.y);
            position.z = this.transform.position.z;
            Instantiate(enemy, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
