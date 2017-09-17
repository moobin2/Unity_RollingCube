using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Broken : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Start Weight Check");

        if (collision.gameObject.tag != "Player") return;

        if (Mathf.Abs(this.gameObject.transform.position.x - collision.transform.position.x) <= 0.1f)
        {
            if (Mathf.Abs(this.gameObject.transform.position.z - collision.transform.position.z) <= 0.1f)
            {
                this.GetComponent<BoxCollider>().isTrigger = true;
                Manager_GameController.Instance.movable = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine("BrokenBlock");
    }

    public void Setting()
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator BrokenBlock()
    {
        yield return new WaitForSeconds(2.0f);
        Manager_GameController.Instance.StageReset();
    }
}
