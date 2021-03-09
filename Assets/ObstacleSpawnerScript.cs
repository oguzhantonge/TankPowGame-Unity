using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] Spawners;

    [SerializeField]
    private GameObject[] Obstacle;

    [SerializeField]
    private Transform Player;


    void Start()
    {
       
        StartCoroutine("spawn",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        
        float spawnObstacleNumber = Mathf.CeilToInt(Random.Range(0f, 4));

        List<int> spawnPositionsRandomly = new List<int>();
        int i = 0;
        while (i < spawnObstacleNumber)
        {
            int random_int =Mathf.RoundToInt(Random.Range(0, 4));
            if (!spawnPositionsRandomly.Contains(random_int))
            {
                spawnPositionsRandomly.Add(random_int);
                i++;
            }
        }
        
        foreach(int t in spawnPositionsRandomly)
        {
            GameObject ObstacleGenerate = Instantiate(SelectObstacle(), new Vector3(Spawners[t].position.x,2.55f,Player.position.z+100f), Quaternion.identity);
        }
       
    }

    GameObject SelectObstacle()
    {
        int x = Mathf.RoundToInt(Random.Range(0, 4));
        return Obstacle[x];
    }

    IEnumerator spawn()
    {
        float x = Random.Range(0.2f, 4f);
        yield return new WaitForSeconds(x);
        SpawnObstacle();
        StartCoroutine("spawn", 1f);
    }
  
} // CLASS
















