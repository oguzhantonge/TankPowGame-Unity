using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform Player;
    float OffSet_Z = -12f, OffSet_Y =5f;




    void Awake()
    {
        Player = GameObject.Find("Player").transform;
        Cursor.visible = false;
       
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 temp = Player.position + new Vector3(0f, OffSet_Y, OffSet_Z);
        transform.position = temp;

    }


} // class





















