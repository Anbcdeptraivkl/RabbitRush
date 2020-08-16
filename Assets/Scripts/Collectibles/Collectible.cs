using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int point = 1;
    Rigidbody2D rgbd;
    // Add Point if Player Collected (Tag checking)
    
    // Getter
    public int Point {
        get {
            return point;
        }
    }

    void Start() {
        rgbd = GetComponent<Rigidbody2D>();
        Move();
    }

    public void StopMoving() {
        rgbd.velocity = Vector2.zero;
    }

    public void Move() {
        // Moving to the Left at Constant SPeed
        rgbd.velocity = new Vector2(-speed, 0);
    }
    
    // Show Collected Amount inside Game Over Screen (Tracked in the )
}
