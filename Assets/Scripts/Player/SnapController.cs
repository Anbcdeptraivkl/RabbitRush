using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character Snapping Limitted Movements
public class SnapController : MonoBehaviour
{
    public float speed;
    // Distance of each Moves
    public float range;
    Vector3 targetPos;
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        // Origin
        origin = transform.position;
        targetPos = origin;
        // Alive
    }

    // Update Actions if Still playing
    void Update()
    {
        MovePlayer();
        InputHandling();
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
        // Clamping: Fixing the Snap controller to the same range and Coordinates in the editor
        targetPos.y = Mathf.Clamp(targetPos.y, origin.y -range, origin.y + range);
    }

    // Player Fixed Movements
    void MovePlayer() {
        while (transform.position != targetPos) {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
