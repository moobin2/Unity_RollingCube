using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Time : MonoBehaviour {

    private int _time = 99;
    private UILabel _label; 
	// Use this for initialization
	void Awake ()
    {
        _label = GetComponent<UILabel>();
        StartCoroutine("DecreaseSecond");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DecreaseSecond()
    {
        yield return new WaitForSeconds(1.0f);

        _time--;

        _label.text = _time.ToString();

        if (_time > 0)
        {
            StartCoroutine("DecreaseSecond");
        }
        else
        {

        }
    }
}
