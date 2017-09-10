using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Movecount : MonoBehaviour
{
    private UILabel _label;

    // Use this for initialization
    void Awake ()
    {
        _label = GetComponent<UILabel>();
	}

    public void SetMoveCount(int moveCount)
    {
        _label.text = moveCount.ToString();
    }
}
