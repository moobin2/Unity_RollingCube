using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Continue : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        if(PlayerPrefs.HasKey("BestStage") == false)
        {
            this.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
