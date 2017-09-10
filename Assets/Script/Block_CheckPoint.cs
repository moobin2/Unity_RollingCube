using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_CheckPoint : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("체크포인트 충돌!");
        GameObject playerCube = collision.gameObject as GameObject;

        float length = Vector2.Distance(new Vector2(playerCube.transform.position.x, playerCube.transform.position.z), new Vector2(this.transform.position.x, this.transform.position.z));

        if (Mathf.Abs(length) < 0.1f)
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //GameObject manager = GameObject.FindGameObjectWithTag("Manager") as GameObject;
        //manager.SendMessage("StageClear");
        Manager_GameController.Instance.StageClear();
    }

    void PrintVector3(Vector3 vec)
    {
        Debug.Log("X : " + vec.x + " , Y : " + vec.y + " , Z : " + vec.z);
    }
}
