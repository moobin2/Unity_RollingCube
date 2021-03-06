﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_ChangeScene : MonoBehaviour
{
    public void ChangeToNextStage()
    {
        int nextStage = Manager_GameController.Instance.CurrentStageNumber + 1;
        string StageSceneName = "Stage_" + nextStage;
        SceneManager.LoadScene(StageSceneName);
    }

    public void RestartStage()
    {
        int nextStage = Manager_GameController.Instance.CurrentStageNumber;
        string StageSceneName = "Stage_" + nextStage;
        SceneManager.LoadScene(StageSceneName);
    }

    public void ChangeToStage1()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void ChageToBestStage()
    {
        if(PlayerPrefs.HasKey("BestStage"))
        {
            string StageSceneName = "Stage_" + PlayerPrefs.GetInt("BestStage");
            SceneManager.LoadScene(StageSceneName);
        }
        else
        {
            SceneManager.LoadScene("Stage_1");
        }
    }

    public void ChangeToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
