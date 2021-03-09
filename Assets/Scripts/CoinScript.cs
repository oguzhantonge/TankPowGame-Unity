using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RotateCoin();
       
       
    }


    void RotateCoin()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.fixedDeltaTime);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            GameManagement.instance.SCORE++;
            PlayerPrefs.SetInt("TotalCoins",PlayerPrefs.GetInt("TotalCoins")+1);

        }

        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Obstacle hit");

            ChangePosition();
        }
    }


    void ChangePosition()
    {
        float x = Random.Range(-3.5f, 5.5f);
        float addZ = Random.Range(1f, 3f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z + addZ);
    }

}
