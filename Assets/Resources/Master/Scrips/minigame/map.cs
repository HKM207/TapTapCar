using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject mapPrefab;
    GameObject firstTile;
    GameObject secondTile;
    public GameObject car;
    int count = 1;

	void Start () {
        Instantiate(mapPrefab, new Vector3(mapPrefab.transform.position.x , 0, 0), Quaternion.identity);
        Instantiate(mapPrefab, new Vector3(mapPrefab.transform.position.x, 0, 56.04755f), Quaternion.identity);
    }

}
