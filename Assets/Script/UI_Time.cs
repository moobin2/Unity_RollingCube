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

    public int TimeToZero()
    {
        Debug.Log("Time To Zero Funtion Call");
        StopCoroutine("DecreaseSecond");
        iTween.ValueTo(this.gameObject, iTween.Hash("from", _time, "to", 0, "onUpdate", "SetTimeText", "time", 1));

        Debug.Log(_time);

        return _time;
    }

    void SetTimeText(int time)
    {
        _label.text = time.ToString();
    }

    public void SubSecond(int time)
    {
        _time -= time;
        if(_time < 0)
        {
            _time = 0;
            StopCoroutine("DecreaseSecond");
            Manager_GameController.Instance.StageFail();
        }
        SetTimeText(_time);
    }

    IEnumerator DecreaseSecond()
    {
        yield return new WaitForSeconds(1.0f);

        SetTimeText(_time);

        _time--;

        if (_time >= 0)
        {
            StartCoroutine("DecreaseSecond");
        }
        else
        {
            Manager_GameController.Instance.StageFail();
        }
    }
}
