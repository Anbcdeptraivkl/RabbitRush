using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroy self over a time period
public class SelfClean: MonoBehaviour {
    public float timer;

    void Start() {
        StartCoroutine(Clean());
    }

    IEnumerator Clean() {
        yield return new WaitForSeconds(timer);
        // Clean Children
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        // Clean self
        Destroy(gameObject);
    }
}