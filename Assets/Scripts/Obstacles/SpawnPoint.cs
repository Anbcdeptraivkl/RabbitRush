using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawn Point Behaviours
public class SpawnPoint : MonoBehaviour
{
    // Obstacles: Can be many types depend on the Prefabs assigned
    public GameObject spawningObj;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Spawning 1 Obstacle prefab on Created while 
    void SpawnObstacle() {
        Instantiate(
            spawningObj,
            transform.position,
            Quaternion.identity
        );
    }
}
