using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("벽충돌");
        Manager_GameController.Instance.movable = false;
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("WallCollision");
        //Manager_GameController.Instance.StateFail();
    }

    IEnumerator WallCollision()
    {
        yield return new WaitForSeconds(0.5f);

        Manager_GameController.Instance.StateFail();
    }
}
