﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_FadeInOut : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
