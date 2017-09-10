using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVEDIRECTION
{
    UP, DOWN, RIGHT, LEFT
}

public class Block_MoveCube : MonoBehaviour {

    public int moveRange = 3;
    public float waitTime = 2.0f;
    public float moveSpeed = 0.1f;
    public DIRECTION dir = DIRECTION.UP;

	// Use this for initialization
	void Awake ()
    {
        StartCoroutine("MoveCube");
	}
	
    IEnumerator MoveCube()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);

            int count = (int)Mathf.Round(moveRange / moveSpeed);
            //(int)(moveRange / moveSpeed);
            Debug.Log("Count : " + count);
            for(int i = 0; i < count; ++i)
            {
                switch(dir)
                {
                    case DIRECTION.UP:
                        this.transform.position += new Vector3(0, 0, moveSpeed);
                        break;
                    case DIRECTION.DOWN:
                        this.transform.position += new Vector3(0, 0, -moveSpeed);
                        break;
                    case DIRECTION.LEFT:
                        break;
                    case DIRECTION.RIGHT:
                        break;
                }

                yield return null;
            }

            ChangeReverseDir();
        }
    }

    void ChangeReverseDir()
    {
        switch (dir)
        {
            case DIRECTION.UP:
                dir = DIRECTION.DOWN;
                break;
            case DIRECTION.DOWN:
                dir = DIRECTION.UP;
                break;
            case DIRECTION.LEFT:
                dir = DIRECTION.RIGHT;
                break;
            case DIRECTION.RIGHT:
                dir = DIRECTION.LEFT;
                break;
        }
    }
}
