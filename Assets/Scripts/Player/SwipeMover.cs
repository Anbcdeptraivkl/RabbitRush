using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement on wipe for Touch Screen Supports
//  - The Movements Scripts are ssociated with Swipe Detector right from the game start
public class SwipeMover : Movement
{
    void Start() {
        // Adding Events to Delegates Stack
        SwipeController.OnSwipe += InputHandling;
        base.Start();
    }

    void LateUpdate() {
        MovePlayer();
    }

    protected void InputHandling(Swipe swipeData) {
        float movement = 0;
        if (swipeData.direction == SwipeDirection.Up) {
            movement = 1;
        } else if (swipeData.direction == SwipeDirection.Down) {
            movement = -1;
        }
        // Fixed Move Steps
        movement *= range;
        // DOn't move along the X axis
        targetPos = new Vector3(transform.position.x, transform.position.y + movement, transform.position.z);
        // Clamping: Fixing the Snap controller to the same range and Coordinates in the editor
        targetPos.y = Mathf.Clamp(targetPos.y, origin.y -range, origin.y + range);
    }

    void OnDestroy() {
        // Removing Events when the OBject is no longer available
        SwipeController.OnSwipe -= InputHandling;
    }
}
