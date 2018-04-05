using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour {

    private ReadData dataReader;
    private Timer timer;

	// Use this for initialization
	void Start () {
        timer = gameObject.GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (timer.strHrs == "01"){
            print("1 hour"); 
        }
		
	}
}
