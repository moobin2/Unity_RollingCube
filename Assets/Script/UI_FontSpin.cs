using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FontSpin : MonoBehaviour {

    public DIRECTION dir;

    public Vector3 _firstPos;

	// Use this for initialization
	void Awake ()
    {
        _firstPos = this.transform.localPosition;
        Debug.Log(_firstPos.x);

        if(dir == DIRECTION.LEFT)
        {
            this.transform.localPosition = new Vector3(_firstPos.x - 800.0f, this._firstPos.y, this._firstPos.z);
        }
        else if (dir == DIRECTION.RIGHT)
        {
            this.transform.localPosition = new Vector3(_firstPos.x + 800.0f, this._firstPos.y, this._firstPos.z);
        }
    }

    private void Start()
    {
        SpinFont();
    }

    //IEnumerator SpinFont(DIRECTION dir)
    //{

    //}

    void SpinFont()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("time", 3.0f, "islocal", true, "position", _firstPos, "easetype", "Linear"));
        iTween.RotateBy(this.gameObject, new Vector3(0, 0, 1), 3.0f);



    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
