using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract Classes for All kind of Movements Supported
//  - Base class that could not be instantiated on its own
public abstract class Movement : MonoBehaviour
{
    public float speed;
    // Distance of each Moves
    public float range;
    protected Vector3 targetPos;
    protected Vector3 origin;

    bool movable = true;

    protected void Start() {
         // Origin
        origin = transform.position;
        targetPos = origin;
        // Alive
    }

    public void StopMoving() {
        movable = false;
    }

    // Player Fixed Movements
    protected void MovePlayer() {
        while (transform.position != targetPos && movable) {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

}
