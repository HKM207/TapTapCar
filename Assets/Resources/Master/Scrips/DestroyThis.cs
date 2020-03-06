using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
	private void FixedUpdate()
    {
        Invoke("DisableThis", 2.5f);
        //Destroy(this.gameObject, 1.25f);
	}

    private void DisableThis()
    {
        if (this.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
        }

    }
}
