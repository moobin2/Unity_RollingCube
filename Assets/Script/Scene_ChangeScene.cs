using System.Collections;
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

    public void ChangeToStage1()
    {
        SceneManager.LoadScene("Stage_1");
    }

    public void ChangeToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
