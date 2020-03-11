using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    GameObject Car;
    GameObject floor;
    float floorscale = 0;
    void Start()
    {
        Car = GameObject.FindGameObjectWithTag("car");
        floor = this.gameObject.transform.Find("floor").gameObject;
        floorscale = floor.transform.localScale.z;
    }

    void Update()
    {
        MoveTiles();

    }

    void MoveTiles()
    {
        if (Car.transform.position.z >= this.gameObject.transform.position.z + floorscale)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + floorscale * 2);
            SpawnObjects(this.gameObject.transform.position.z);
        }
    }

    void SpawnObjects(float tilePos)
    {
        int lane = Random.Range(-1, 2);
        if (!logic.isPoolFull)
        {
            logic.InstantiateObject(Instantiate(logic.obstaclePrefab, new Vector3( 3* lane , this.gameObject.transform.position.y, this.gameObject.transform.position.z) , Quaternion.identity), true);
        }
        else
        {
            logic.obstacleList[logic.poolsize - 1].transform.position = new Vector3(3 * lane, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

    }
}
