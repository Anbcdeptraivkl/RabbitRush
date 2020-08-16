using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float startWait = 1f;
    public float scrollSpeed = 0.55f;
    Renderer rd;
    float waitLimit = 0f;
    bool scrolling = true;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    // Offseting the Background each Frame following the specified speed
    void Update()
    {
        if (scrolling) {
            // Waiting time
            if (waitLimit < startWait) {
                waitLimit += Time.deltaTime;
                return;
            }
            
            Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);
            rd.material.mainTextureOffset = offset;
        }
        
    }

    public void StopScrolling() {
        scrolling = false;
    }
}
