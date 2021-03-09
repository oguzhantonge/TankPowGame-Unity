using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    public GameObject OtherGround;
    private GameObject player;
    private float offSet = 20f;
    private float groundSize = 250f;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGround();
    }



    void CheckForGround()
    {
        if(player.transform.position.z >= OtherGround.transform.position.z + groundSize / 2 + offSet)
        {
            Vector3 temp = OtherGround.transform.position;
            temp.z += groundSize * 2;
            OtherGround.transform.position = temp;

        }
    }
}
