using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Manager_GameController : MonoBehaviour
{
    private static Manager_GameController instance = null;
    public static Manager_GameController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType(typeof(Manager_GameController)) as Manager_GameController;
            }
            return instance;
        }
    }

    public float startTime = 3.0f;
    public bool movable = false;
    public GameObject ui;
    public GameObject player;
    public GameObject map;
    public bool isPlayerTNT;
    public int movableCount;

    public int CurrentStageNumber;
    private bool _isReseting = false;
    private List<Block_StartMove>   _blockStartList;
    private List<Block_Switch>      _blockSwitchList;
    private List<Block_Broken>      _blockBrokenList;

	// Use this for initialization
	void Awake ()
    {
        char StageNumberString = EditorApplication.currentScene[EditorApplication.currentScene.Length - 7];
        Debug.Log(StageNumberString);
        CurrentStageNumber = (int)StageNumberString - 48;
        Debug.Log(CurrentStageNumber);
        int mapChildSize = map.transform.childCount;
        _blockStartList = new List<Block_StartMove>();
        _blockSwitchList = new List<Block_Switch>();
        _blockBrokenList = new List<Block_Broken>();

        for (int i = 0; i < mapChildSize; i++)
        {
            GameObject tempBlock = map.transform.GetChild(i).gameObject;

            if (tempBlock.tag == "Block")
            {
                _blockStartList.Add( tempBlock.GetComponent<Block_StartMove>() );
            }
            else if(tempBlock.tag == "Switch")
            {
                _blockStartList.Add(tempBlock.GetComponent<Block_StartMove>());
                _blockSwitchList.Add( tempBlock.GetComponent<Block_Switch>() );
            }
            else if(tempBlock.tag == "Broken")
            {
                _blockStartList.Add(tempBlock.GetComponent<Block_StartMove>());
                _blockBrokenList.Add(tempBlock.GetComponent<Block_Broken>());
            }
            else
            {

            }
        }
	}

    private void Start()
    {
        StartCoroutine("SettingStage");
    }

    public void StageClear()
    {
        Debug.Log("Stage Clear");

        UI_Controller uiController = ui.GetComponent<UI_Controller>();

        uiController.CalculateScore();

        ui.transform.GetChild(4).gameObject.SetActive(true);
        movable = false;
    }

    public void StageFail()
    {
        Debug.Log("Stage Fail");

        UI_Controller uiController = ui.GetComponent<UI_Controller>();

        ui.transform.GetChild(5).gameObject.SetActive(true);

        movable = false;
    }

    public void StageReset()
    {
        if (_isReseting == true) return;
        Debug.Log("Stage Reset");

        UI_Controller uiController = ui.GetComponent<UI_Controller>();
        uiController.TimePenalty(10);

        player.GetComponent<Player_Controller>().ResetCube();

        StartCoroutine("SettingStage");
    }

    IEnumerator SettingStage()
    {
        _isReseting = true;
        foreach(Block_StartMove blocks in _blockStartList)
        {
            blocks.StartMove();
        }

        foreach(Block_Switch switchs in _blockSwitchList)
        {
            switchs.Setting();
        }

        foreach(Block_Broken brokens in _blockBrokenList)
        {
            brokens.Setting();
        }

        yield return new WaitForSeconds(startTime);

        ui.SetActive(true);
        player.SetActive(true);

        movable = true;
        _isReseting = false;
    }
}
