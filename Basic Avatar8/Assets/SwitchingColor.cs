using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingColor : MonoBehaviour
{
    public Color colorStart = Color.red;
    Color colorEnd = Color.green;
    float duration = 1.0f;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update ()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);

    }
}
