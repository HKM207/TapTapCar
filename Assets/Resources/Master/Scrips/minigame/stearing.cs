using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stearing : MonoBehaviour
{

    float movespeed = 0f;
    public static bool start = false;
    public Camera MainCamera;

    //dond tatch men
    private int DelayAmount = 1;
    private float Timer;
    void Start()
    {

    }

    void Update()
    {
        MoveAcceleration();
        this.gameObject.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        SwitchSides();
        MainCamera.transform.position = new Vector3(0f, MainCamera.transform.position.y, MainCamera.transform.position.z);
        Timer += Time.deltaTime;
    }

    void MoveAcceleration()
    {
        if (Input.GetKeyDown(KeyCode.W) && !start)
        {
            start = true;
            movespeed = 20f;
        }
        else if (start)
        {
            if (Timer >= DelayAmount)
            {
                Timer = 0f;
                movespeed += 2;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            logic.Lose();
        }
    }
    void SwitchSides()
    {
        if (start)
        {
            if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            {
                if (this.gameObject.transform.position.x >= 0)
                {
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
            {
                if (this.gameObject.transform.position.x <= 0)
                {
                    this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 3, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
            {

            }
        }
    }
}
