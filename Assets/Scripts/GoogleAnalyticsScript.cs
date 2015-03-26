using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoogleAnalyticsScript : MonoBehaviour {
    public GoogleAnalyticsV3 googleAnalytics;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("StaticObject") == null)
        {
            Debug.LogError("Not Exist StaticObject for google analytics and admob");
            
        }
        else
        {
            googleAnalytics = GameObject.Find("GAv3").GetComponent<GoogleAnalyticsV3>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
