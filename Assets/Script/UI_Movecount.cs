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
        if (Manager_GameController.Instance.isPlayerTNT == true)
        {
            _label.text = Manager_GameController.Instance.movableCount.ToString();
        }
    }

    //private void Start()
    //{
    //    if (Manager_GameController.Instance.isPlayerTNT == true)
    //    {
    //        _label.text = Manager_GameController.Instance.movableCount.ToString();
    //    }
    //}

    public void SetMoveCount(int moveCount)
    {
        _label.text = moveCount.ToString();
    }
}
