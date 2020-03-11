using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic : MonoBehaviour
{
    public static float playTime = 0;
    public static List<GameObject> obstacleList = new List<GameObject>();
    public static List<GameObject> RewardList = new List<GameObject>();
    public static bool isPoolFull = false;
    public static int poolsize = 10;

    public static GameObject obstaclePrefab;
    void Start()
    {
        obstaclePrefab = Resources.Load<GameObject>("Prefabs/minigame/Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if (stearing.start)
        {
            playTime += Time.deltaTime;
        }
    }
    public static void Lose()
    {
        Debug.Log("survival time: " + playTime);
    }


    public static void InstantiateObject(GameObject instantiatedObject, bool isObstacle)
    {
        if (!isPoolFull)
        {
            if (isObstacle)
            {
                obstacleList.Add(instantiatedObject);
                if (obstacleList.Count >= poolsize)
                {
                    isPoolFull = true;
                }
            }
        }
        else
        {
            Debug.Log("pool  is full");
        }

    }
}
