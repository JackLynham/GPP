using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour {

    // Use this for initialization
    #region Singleton

    public static TrackPlayer instance;
 void Awake()
    {
        instance = this;

    }

    #endregion
    public GameObject player;
   
}
