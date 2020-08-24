using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for Mobile: Detecting Movement with Swiping Inputs
public class SwipeController : MonoBehaviour
{
    // Whether the Detection is continous or only after releasing touch
    [SerializeField]
    bool swipeOnlyOnRelease = true;
    // Minimum distance for the swiping to be recognised
    [SerializeField]
    float minDistance = 1f;
    // WHere you touch
    Vector2 pressPosition;
    // Where you release
    Vector2 liftPosition;
    // Delegate Event(s) for Swipe: take Swipe Data as Arguments
    public static event Action<Swipe> OnSwipe = delegate {};


    // Update is called once per frame
    void Update() {
        SwipeInputHandling();
    }

    void SwipeInputHandling() {
        // Detect only 1 touch at a time
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            // Detect Swipe using Touch Phase
            if (touch.phase == TouchPhase.Began) {
                // At the beginning, the 2 points are at the same position
                pressPosition = touch.position;
                liftPosition = touch.position;
            }
            // Continous Detection
            if (!swipeOnlyOnRelease && touch.phase == TouchPhase.Moved) {
                // The Swiping-to Position
                liftPosition = touch.position;
                DetectSwipe();
            }
            // For Swiping only on Releasing
            if (touch.phase == TouchPhase.Ended) {
                liftPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe() {
        Debug.Log("Swiped!");
        if (SwipeDistancePassed()) {
            Debug.Log("Distance Passed");
            // Only check for Vertical Swipe (horizontal don't count at all)
            if (IsVerticalSwipe()) {
                Debug.Log("Vertical Passed");
                // Direction checks based on Pressing and Releasing Final Positions
                SwipeDirection direction = liftPosition.y > pressPosition.y ? SwipeDirection.Up : SwipeDirection.Down;
                SwipeRespond(direction);
            }
            // Reset the Swipe Data and ready to receive new swipe input
            liftPosition = pressPosition;
        }
    }

    // Distance Check
    bool SwipeDistancePassed() {
        return Mathf.Abs(Vector2.Distance(liftPosition, pressPosition)) > minDistance;
    }

    // Distance check Supporting Methods
    bool IsVerticalSwipe() {
        Debug.Log(VerticalSwipeDistance() + " | " + HorizontalSwipeDistance());
        return VerticalSwipeDistance() > HorizontalSwipeDistance();
    }

    float VerticalSwipeDistance() {
        return Mathf.Abs(liftPosition.y - pressPosition.y);
    }

    float HorizontalSwipeDistance() {
        return Mathf.Abs(liftPosition.x - pressPosition.x);
    }

    void SwipeRespond(SwipeDirection dir) {
        Debug.Log(dir);
        Swipe swipe = new Swipe {
            startPosition = pressPosition,
            endPosition = liftPosition,
            direction = dir
        };
        // RUn Delegate Event(s)
        OnSwipe(swipe);
    }
}

// Swipe Data and Status
public struct Swipe {
    public Vector2 startPosition;
    public Vector2 endPosition;
    public SwipeDirection direction;
}

public enum SwipeDirection {
    Up,
    Down,
    Left,
    Right
}
