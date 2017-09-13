using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Point : MonoBehaviour
{
    private int _scorePoint;
    private UILabel _label;
    private void Awake()
    {
        _scorePoint = 0;
        _label = this.gameObject.GetComponent<UILabel>();
        _label.text = _scorePoint.ToString();
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseScore(int time)
    {
        _scorePoint = time * 10;
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0, "to", _scorePoint, "onUpdate", "SetScoreText", "time", 1));
    }

    void SetScoreText(int Score)
    {
        _label.text = Score.ToString();
    }
}
