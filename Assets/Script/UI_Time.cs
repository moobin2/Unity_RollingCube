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
	void Update ()
    {
    }

    public int TimeToZero()
    {
        Debug.Log("여기 불려짐");
        StopCoroutine("DecreaseSecond");
        iTween.ValueTo(this.gameObject, iTween.Hash("from", _time, "to", 0, "onUpdate", "SetTimeText", "time", 1));

        Debug.Log(_time);

        return _time;
    }

    void SetTimeText(int time)
    {
        _label.text = time.ToString();
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
