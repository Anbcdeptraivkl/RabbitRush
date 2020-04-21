using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Master Class: Status and Animations
public class Player : MonoBehaviour
{
    // References
    SnapController controller;
    Animator animator;
    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SnapController>();
        animator = GetComponent<Animator>();
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
