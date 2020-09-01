using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Background is consisted of 2 Sprites: One Main and One Sub placed next to each others to create an Illusion of Infinite Scrolling
//  - Both of them will move at constant Speed corresponding to the Obstacles and Difficulty of the game at the time
//  - After the Main is Out of Camera, the Backgrounds Positions will be Reseted 
public class Background : MonoBehaviour
{
    public float startWait = 1f;
    public float scrollSpeed = 10f;
    Renderer rd;
    // Position to Reset to
    Vector2 startingPosition;
    Rigidbody2D rgbd;
    float waitLimit = 0f;
    bool scrolling = true;

    void Start()
    {
        rd = GetComponent<Renderer>();
        rgbd = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        StartCoroutine(StartScrolling());
    }

    IEnumerator StartScrolling() {
        yield return new WaitForSeconds(startWait);
        while (scrolling) {
            rgbd.velocity = new Vector2(-(scrollSpeed * Score.Difficulty), 0);
            yield return null;
        }
    }

    void OnBecameInvisible() {
        // Only apply to the Main part of the Background
        if (gameObject.CompareTag("MainBackground"))
            transform.position = startingPosition;
    }

    public void StopScrolling() {
        rgbd.velocity = Vector2.zero;
        scrolling = false;
    }
}
