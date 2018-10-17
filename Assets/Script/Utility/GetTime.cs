using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GetTime : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        UpDateTime();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  UpDateTime() {
        text.text = DateTime.Now.ToString("dddd,MMMM,dd ,yyyy", new System.Globalization.DateTimeFormatInfo());
    }
}
