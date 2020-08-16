using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Control the Tooltip UI Behaviours
public class Tooltip : MonoBehaviour
{
    // Self-References
    Image background;
    Text text;

    void Start() {
        // Hide by Default
        text = transform.Find("Text").gameObject.GetComponent<Text>();
        background = GetComponent<Image>();
        Hide();
    }

    public void Activate(string tip) {
        //Positioning depend on at the top or the bottom part of the screen
        if (transform.position.y < Screen.height / 2) {
            GetComponent<RectTransform>().pivot = new Vector2(0, 0);
        } else {
            GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        }
        transform.position = Input.mousePosition;
        // Enablers
        background.enabled = true;
        text.text = tip;
    }

    public void Hide() {
        text.text = "";
        background.enabled = false;
    }
}
