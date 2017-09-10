using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_StartMove : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        iTween.RotateTo(this.gameObject, new Vector3(30, 360, 0), Manager_GameController.Instance.startTime);

        this.transform.LookAt(Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
