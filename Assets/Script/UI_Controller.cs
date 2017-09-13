using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public GameObject TimeUIObject;
    public GameObject MoveUIObject;
    public GameObject PointUIObject;

    private UI_Time         _uiTime;
    private UI_Point        _uiPoint;
    private UI_Movecount    _uiMoveCount;

    private void Awake()
    {
        _uiTime = TimeUIObject.GetComponent<UI_Time>();
        _uiPoint = PointUIObject.GetComponent<UI_Point>();
        _uiMoveCount = MoveUIObject.GetComponent<UI_Movecount>();
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CalculateScore()
    {
        int leftTime = _uiTime.TimeToZero();
        _uiPoint.IncreaseScore(leftTime);

        //this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
}
