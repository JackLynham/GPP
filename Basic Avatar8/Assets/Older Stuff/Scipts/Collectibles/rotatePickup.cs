using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotatePickup : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(15, 45, -15) * Time.deltaTime);
    
    }


   

}
