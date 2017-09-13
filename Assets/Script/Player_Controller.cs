using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CUBESATE
{
    HORIZON_X, HORIZON_Z, VERTICAL
}

public enum DIRECTION
{
    UP, DOWN, RIGHT, LEFT
}

public class Player_Controller : MonoBehaviour
{
    public CUBESATE _state;
    public float _height;
    public float _width;
    public GameObject moveText;

    private int _moveCount;
    private Vector3 _pivot;
    private Vector3 _axis;
    private bool _isTurning;
    private Vector3 _firstPos;
    private Quaternion _currentRot = Quaternion.identity;
    private BoxCollider _boxColl;
    private Rigidbody _rigid;
    private UI_Movecount _moveCountText;

    private void Awake()
    {
        _boxColl = this.GetComponent<BoxCollider>();
        _rigid = this.GetComponent<Rigidbody>();
        _moveCountText = moveText.GetComponent<UI_Movecount>();
        _moveCount = 0;

        _state = CUBESATE.VERTICAL;
        _isTurning = false;
        _height = this.transform.childCount / 2;
        _width = this.transform.localScale.x / 2;

        _firstPos = this.transform.position;
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Manager_GameController.Instance.movable == false) return;

        if (_isTurning == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine("TurningCube", DIRECTION.UP);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine("TurningCube", DIRECTION.DOWN);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine("TurningCube", DIRECTION.LEFT);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine("TurningCube", DIRECTION.RIGHT);
            }
        }
    }

    void SetState(DIRECTION dir)
    {
        switch (_state)
        {
            case CUBESATE.HORIZON_X:
                {
                    if (dir == DIRECTION.RIGHT || dir == DIRECTION.LEFT)
                    {
                        _state = CUBESATE.VERTICAL;
                    }
                    break;
                }
            case CUBESATE.HORIZON_Z:
                {
                    if (dir == DIRECTION.UP || dir == DIRECTION.DOWN)
                    {
                        _state = CUBESATE.VERTICAL;
                    }
                    break;
                }
            case CUBESATE.VERTICAL:
                {
                    if (dir == DIRECTION.UP || dir == DIRECTION.DOWN)
                    {
                        _state = CUBESATE.HORIZON_Z;
                    }
                    else
                    {
                        _state = CUBESATE.HORIZON_X;
                    }
                    break;
                }
        }

        //ResiseColliderbox();
    }

    void SetPivot(DIRECTION dir)
    {
        Debug.Log(dir.ToString());
        _pivot = this.transform.position;

        // 플레이어큐브가 세로로 서있을때
        if (_state == CUBESATE.VERTICAL)
        {
            _pivot.y -= _height;
        }
        else
        {
            _pivot.y -= _width;
        }

        switch (dir)
        {
            case DIRECTION.UP:
                if (_state == CUBESATE.HORIZON_Z)
                {
                    _pivot.z += _height;
                }
                else
                {
                    _pivot.z += _width;
                }
                break;
            case DIRECTION.DOWN:
                if (_state == CUBESATE.HORIZON_Z)
                {
                    _pivot.z -= _height;
                }
                else
                {
                    _pivot.z -= _width;
                }
                break;
            case DIRECTION.LEFT:
                if (_state == CUBESATE.HORIZON_X)
                {
                    _pivot.x -= _height;
                }
                else
                {
                    _pivot.x -= _width;
                }
                break;
            case DIRECTION.RIGHT:
                if (_state == CUBESATE.HORIZON_X)
                {
                    _pivot.x += _height;
                }
                else
                {
                    _pivot.x += _width;
                }
                break;
        }
    }

    void SetAxis(DIRECTION dir)
    {
        switch (dir)
        {
            case DIRECTION.UP:
            case DIRECTION.DOWN:
                _axis = new Vector3(1.0f, 0.0f, 0.0f);
                break;
            case DIRECTION.RIGHT:
            case DIRECTION.LEFT:
                _axis = new Vector3(0.0f, 0.0f, 1.0f);
                break;
        }
    }

    void SetCurrentPos(DIRECTION dir)
    {
        switch (dir)
        {
            case DIRECTION.UP:
                _currentRot.x += 90;
                break;
            case DIRECTION.DOWN:
                _currentRot.x -= 90;
                break;
            case DIRECTION.LEFT:
                _currentRot.z += 90;
                break;
            case DIRECTION.RIGHT:
                _currentRot.z -= 90;
                break;
        }

        //this.transform.position = _currentPos;
        this.transform.rotation = _currentRot;
    }

    IEnumerator TurningCube(DIRECTION dir)
    {
        _moveCount++;
        _moveCountText.SetMoveCount(_moveCount);

        _isTurning = true;
        SetGravity(false);

        SetPivot(dir);
        SetAxis(dir);

        int count = 15;
        int mark;

        if (dir == DIRECTION.UP || dir == DIRECTION.LEFT) mark = 1;
        else mark = -1;

        for (int i = 0; i < count; ++i)
        {
            this.transform.RotateAround(_pivot, _axis, 90 / count * mark);
            yield return null;
        }

        SetState(dir);
        _isTurning = false;
        SetGravity(true);
    }

    public void ResetCube()
    {
        StopCoroutine("TurningCube");
        this.transform.position = _firstPos;
        this.transform.rotation = _currentRot = Quaternion.identity;
        //_rigid.velocity = Vector3.zero;
        //_rigid.WakeUp();
        _rigid.velocity = Vector3.zero;

        _rigid.angularVelocity = Vector3.zero;

        _rigid.Sleep();

        _state = CUBESATE.VERTICAL;
        _isTurning = false;
        SetGravity(true);
        this.gameObject.SetActive(false);
    }

    void SetGravity(bool isGravity)
    {
        _rigid.useGravity = isGravity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_pivot, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, 0.1f);
    }
}
