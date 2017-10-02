using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsReset : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteKey("BestStage");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
