using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Wall : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("벽충돌");
        Manager_GameController.Instance.movable = false;

        StartCoroutine("WallCollision");
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("WallCollision");
        //Manager_GameController.Instance.StateFail();
    }

    IEnumerator WallCollision()
    {
        yield return new WaitForSeconds(2.0f);

        Manager_GameController.Instance.StageReset();
    }
}
