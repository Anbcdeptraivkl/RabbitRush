using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Alternating between 2 Phase
public enum SpawningPhase {
    Obstacles,
    Collectibles
}

// Control Spawning Phase, Patterns and Interval of Obstacles and Collectibles (with Upgrades and Chances )
public class SpawnController : MonoBehaviour
{
    public float startWait = 1f;
    // Time between Waves
    public float waveInterval;
    // Time of each Obstacles / Collectibles Phase
    public float minPhase = 2f, maxPhase = 4f;
    // obsPatterns of Spawn points for each Units and Waves
    bool spawning;
    // Where to generate Spawn Points
    public Transform spawnPosition;
    // Current Spawning Types: Always Obstacles First
    SpawningPhase currentPhase = SpawningPhase.Obstacles;

    [Header("Obsacles")]
    
    public GameObject[] obsPatterns;

    [Header("Collectibles")]

    // List of Collectibles Patterns Prefabs
    public GameObject[] collectibles;

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        StartCoroutine(Spawn());
    }

    void Update() {

    }

    public void StopSpawning() {
        spawning = false;
    }

    
    // Spawn Alternating between Obstacles and Collectibles Phase
    IEnumerator Spawn() {
        yield return new WaitForSeconds(startWait);
        while (spawning) {
            // Random Phase Time
            float phaseDuration = Random.Range(minPhase, maxPhase);
            // Random Patterns and Amounts of Waves for each Phase
            // - Nested Coroutines: Wait until Finish Spawning before moving to new Phase
            switch (currentPhase) {
                case SpawningPhase.Obstacles: {
                    yield return StartCoroutine(SpawnObsPattern(phaseDuration));
                }
                break;

                case SpawningPhase.Collectibles: {
                    yield return StartCoroutine(SpawnCollectibles(phaseDuration));
                }
                break;
            }
        }
    }

    IEnumerator SpawnObsPattern(float duration) {
        float currentPhaseTime = 0f;
        // Randomize and Spawn Patterns
        while (spawning && duration > currentPhaseTime) {
            GameObject pattern = obsPatterns[Random.Range(0, obsPatterns.Length)];
            Instantiate(
                pattern,
                spawnPosition.position,
                Quaternion.identity
            );
            // Accumulate Time
            currentPhaseTime += waveInterval;
            yield return new WaitForSeconds(waveInterval);
        }
        currentPhase = SpawningPhase.Collectibles;
    }
    IEnumerator SpawnCollectibles(float duration) {
        float currentPhaseTime = 0f;
        // Randomize and Spawn Patterns
        while (spawning && duration > currentPhaseTime) {
            GameObject collectible = collectibles[Random.Range(0, collectibles.Length)];
            // Collectibles are Spawned in Bulk into Groups
            Instantiate(
                    collectible,
                    spawnPosition.position,
                    Quaternion.identity
                );
            // - Pause between Groups
            currentPhaseTime += waveInterval;
            yield return new WaitForSecondsRealtime(waveInterval);
            //  - Move on to new Patterns until duration Over
        }
        // Switch Phase
        currentPhase = SpawningPhase.Obstacles;
    }
}
