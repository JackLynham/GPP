using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour {

   float score = 100000;
    private GameObject player;
    public Text Text;
    bool end;
    // Use this for initialization
   
    private void Awake()
    {
         player = GameObject.FindGameObjectWithTag("Player");
        Text.enabled = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if(!end)
        {
          score -= Time.deltaTime *10;
        }
 
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            end = true;
            Debug.Log (score);
            Text.enabled = true;
        Text.text = "Score: " + score.ToString();
        }
    }
}
