using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Coin;

    private GameObject Player;
    
    void Awake()
    {
        Player = GameObject.Find("Player");
        StartCoroutine("SpawnCoin", 0.1f);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
   

    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5.5f));
     
        float x = Random.Range(-3.5f, 5.5f);
        Instantiate(Coin, new Vector3(x, 1.5f, Player.transform.position.z + 100f), Quaternion.identity);
        StartCoroutine("SpawnCoin", 0.1f);
    }


   
}
