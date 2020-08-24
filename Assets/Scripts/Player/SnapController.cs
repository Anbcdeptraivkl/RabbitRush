using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character Snapping Limitted Movements
public class SnapController : Movement
{
    // Start is called before the first frame update
    void Start()
    { 
        base.Start();
    }

    void LateUpdate() {
        MovePlayer();
        InputHandling();
    }

    // Receive & Process Inputs
    protected void InputHandling() {
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
}
