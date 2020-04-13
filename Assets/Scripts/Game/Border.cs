using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cleaning up things that went off-screen
public class Border: MonoBehaviour {
    public float timer;

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject, timer);
    }
}