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

    public int CurrentStageNumber;
    private bool _isReseting = false;
    private List<Block_StartMove>   _blockStartList;
    private List<Block_Switch>      _blockSwitchList;

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
        Debug.Log("스테이지클리어");
        ui.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void StateFail()
    {
        if (_isReseting == true) return;
        //ui.SetActive(false);
        player.GetComponent<PlayCubeController>().ResetCube();
        Debug.Log("스페이지실패");

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

        yield return new WaitForSeconds(startTime);

        ui.SetActive(true);
        player.SetActive(true);

        movable = true;
        _isReseting = false;
    }
}
