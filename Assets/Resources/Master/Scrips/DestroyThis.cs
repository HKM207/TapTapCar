using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    private void FixedUpdate()
    {
        Invoke("DisableThis", 1.25f);
        //Destroy(this.gameObject, 1.25f);
	}

    private void DisableThis()
    {
        if (this.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            


        }

    }
}
