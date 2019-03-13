using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobSpeedBoost : MonoBehaviour
{
    private float timeleft = 0;
    private bool up = true;
    private bool down = false;
    private void Update()
    {
      
        if (up)
        {
            timeleft += Time.deltaTime;

            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);

            if (timeleft >= 2)
            {
                up = false;
                down = true;
            }

        }

        if (down)
        {
            timeleft -= Time.deltaTime;
            up = false;

            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            if (timeleft <= 0)
            {
                up = true;
                down = false;
            }
        }





    }
}

