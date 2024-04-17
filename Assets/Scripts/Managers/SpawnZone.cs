using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SpawnZone : MonoBehaviour
{
    public Bounds bounds;
    public GameObject subject;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        int currentlySpawned = 0;
        while (currentlySpawned < amount)
        {
            Vector3 spawnedPos = new Vector3();
            spawnedPos.x = UnityEngine.Random.Range(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x);
            spawnedPos.y = UnityEngine.Random.Range(bounds.center.y - bounds.extents.y, bounds.center.y + bounds.extents.y);
            spawnedPos.z = UnityEngine.Random.Range(bounds.center.z - bounds.extents.z, bounds.center.z + bounds.extents.z);
            Instantiate(subject, spawnedPos, Quaternion.identity);
            currentlySpawned++;
        }
        GC.Collect();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
