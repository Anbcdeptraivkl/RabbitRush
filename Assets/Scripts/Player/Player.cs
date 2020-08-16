using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Master Class: Status and Animations
public class Player : MonoBehaviour
{
    // References
    SnapController controller;
    Score scoreMng;
    Animator animator;
    bool alive;
    int collectCount = 0;

    public int Collected {
        get {
            return collectCount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SnapController>();
        animator = GetComponent<Animator>();
        scoreMng = GameObject.FindWithTag("GameController").GetComponent<Score>();
        // Alive
        alive = true;  
    }

    // Stop Controlling if Game Over
    void Update()
    {
        if (!alive) {
            controller.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // Absorb Collectibles Score
        // Remember to Set up Trigger Collider for the Collectibles and Obstacles
        if (collider.gameObject.CompareTag("Collectible")) {
            int point = collider.gameObject.GetComponent<Collectible>().Point;
            scoreMng.AddScore(point);
            collectCount++;
            Destroy(collider.gameObject);
        }
         // Die on touching Obstacles
        if (collider.gameObject.CompareTag("Obstacle")) {
            Die();
        }
    }

    public bool CheckAlive() {
        return alive;
    }

    void Die() {
        alive = false;
        animator.SetTrigger("Die");
    }
}
