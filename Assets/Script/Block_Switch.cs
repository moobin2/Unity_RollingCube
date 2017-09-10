using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Switch : MonoBehaviour
{
    public GameObject[] WallBlocks;
    public GameObject[] LoadBlocks;
    public Material     SwitchOnMaterial;

    private Material    SwitchOffMaterial;

    private void Awake()
    {
        SwitchOffMaterial = this.gameObject.GetComponent<MeshRenderer>().material;

        Setting();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 벽이 살아있다면
        if (WallBlocks[0].active == true)
        {
            Debug.Log("Switch Event Start");

            this.gameObject.GetComponent<MeshRenderer>().material = SwitchOnMaterial;
            // 벽 비활성화
            foreach (GameObject blocks in WallBlocks)
            {
                blocks.SetActive(false);
            }

            foreach (GameObject blocks in LoadBlocks)
            {
                blocks.SetActive(true);
                blocks.GetComponent<Block_StartMove>().StartMove(0.5f);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Switch trigger on");
        // 벽이 살아있다면
        if (WallBlocks[0].active == true)
        {
            // 벽 비활성화
            foreach (GameObject blocks in WallBlocks)
            {
                blocks.SetActive(false);
            }

            foreach (GameObject blocks in WallBlocks)
            {
                blocks.SetActive(true);
                blocks.GetComponent<Block_StartMove>().StartMove(0.5f);
            }

        }
    }

    public void Setting()
    {
        // 길에 있는 벽 활성화
        foreach (GameObject blocks in WallBlocks)
        {
            blocks.SetActive(true);
        }

        // 길은 비활성화.
        foreach (GameObject blocks in LoadBlocks)
        {
            blocks.SetActive(false);
        }

        this.gameObject.GetComponent<MeshRenderer>().material = SwitchOffMaterial;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
