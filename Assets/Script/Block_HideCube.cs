using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_HideCube : MonoBehaviour {

    public float startTime = 0.0f;
    public float waitTime = 2.0f;

    private Vector3 _baseSize;
    private BoxCollider _boxCollider;
    private MeshRenderer _renderer;
    private bool _isHide = false;

    void Awake ()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
        _renderer = this.GetComponent<MeshRenderer>();
        _renderer.material.SetFloat("_Mode", 3.0f);

        StartCoroutine("HideCube");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator HideCube()
    {
        yield return new WaitForSeconds(waitTime);

        for(int i = 0; i < 10; ++i)
        {
            if(_isHide == false)
            {
                _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a - 0.1f);
            }
            else
            {
                _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, _renderer.material.color.a + 0.1f);
            }

            yield return null;
        }

        _boxCollider.isTrigger = _isHide = !_isHide;

        if(_isHide == false)
            yield return new WaitForSeconds(waitTime);

        StartCoroutine("HideCube");
    }
}
