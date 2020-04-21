using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control Spawn Points and Intervals between waves of Obstacles
public class SpawnController : MonoBehaviour
{
    // Where to Generate Spawn points
    public Transform spawnPosition;
    // Patterns of Spawn poins
    public GameObject[] patterns;
    public float startWait = 1f;
    // Time between Waves
    public float interval;
    bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        StartCoroutine(SpawnPatterns());
    }

    void Update() {

    }

    public void StopSpawning() {
        spawning = false;
    }

    IEnumerator SpawnPatterns() {
        yield return new WaitForSeconds(startWait);
        while(spawning) {
            GameObject pattern = RandomPattern();

            Instantiate(
                pattern,
                spawnPosition.position,
                Quaternion.identity
            );

            yield return new WaitForSeconds(interval);
        }
    }

    GameObject RandomPattern() {
        return patterns[Random.Range(0, patterns.Length - 1)];
    }
}
