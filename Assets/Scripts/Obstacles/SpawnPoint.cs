using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy Spawn Point Behaviours
public class SpawnPoint : MonoBehaviour
{
    // Obstacles: Can be many types depend on the Prefabs assigned
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Sequence of Spawning
    IEnumerator SpawnPointSequence() {
        SpawnObstacle();
        yield return null;
    }

    // Spawning 1 Obstacle prefab on Created while 
    void SpawnObstacle() {
        Instantiate(
            obstacle,
            transform.position,
            Quaternion.identity
        );
    }
}
