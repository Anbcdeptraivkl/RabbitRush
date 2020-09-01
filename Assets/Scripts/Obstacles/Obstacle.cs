using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Obstacle Behaviours
public class Obstacle: MonoBehaviour {
    public float speed = 10f;
    Rigidbody2D rgbd;

    void Start() {
        rgbd = GetComponent<Rigidbody2D>();
        Move();
    }

    public void StopMoving() {
        rgbd.velocity = Vector2.zero;
    }

    void Move() {
        // Moving to the Left at Constant SPeed
        rgbd.velocity = new Vector2(-(speed * Score.Difficulty), 0);
    }
}