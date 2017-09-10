using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_StartMove : MonoBehaviour
{
    private Vector3 _firstPos;
    private Vector3 _tempPos;
    // Use this for initialization
    void Awake()
    {
        _firstPos = this.transform.position;

        //StartMove();
    }

    int RandomMark()
    {
        int mark = Random.Range(0, 2);
        if (mark == 0) mark--;
        return mark;
    }
	
    public void StartMove(float BlockMoveTime = 0.0f)
    {
        float moveTime;

        if(BlockMoveTime == 0.0f)
        {
            moveTime = Manager_GameController.Instance.startTime;
        }
        else
        {
            moveTime = BlockMoveTime;
        }
        int mark = Random.Range(0, 2);

        if (mark == 0) mark--;

        this.transform.position = _tempPos = new Vector3(Random.Range(0, 30) * RandomMark(), _firstPos.y + Random.Range(0, 10) * RandomMark(), Random.Range(0, 30) * RandomMark());

        iTween.MoveTo(this.gameObject, _firstPos, moveTime);
    }
}
