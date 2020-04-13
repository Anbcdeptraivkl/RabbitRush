using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Master Class
public class Player : MonoBehaviour
{
    public float speed;
    // Distance of each Moves
    public float range;

    Vector3 targetPos;
    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        // Origin
        targetPos = transform.position;
        // Alive
        alive = true;   
    }

    // Update Actions if Still playing
    void Update()
    {
        if (alive) {
            MovePlayer();
            InputHandling();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Die on touching Obstacles
        if (other.gameObject.CompareTag("Obstacle")) {
            alive = false;
        }
    }

    public bool CheckAlive() {
        return alive;
    }

    // Receive & Process Inputs
    void InputHandling() {
        float movement = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
           movement = 1;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            movement = -1;
        }
        // Fixed Move Steps
        movement *= range;
        // DOn't move along the X axis
        targetPos = new Vector3(transform.position.x, transform.position.y + movement, transform.position.z);
    }

    // Player Fixed Movements
    void MovePlayer() {
        while (transform.position != targetPos) {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            // Clamping
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -range, range));
        }
    }
}
