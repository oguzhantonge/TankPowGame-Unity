using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{

    public Vector3 speed;

    protected float x_Speed = 8f, z_speed = 10f,min_z_speed = 8f;

    protected bool is_speed = false;

    protected float rotationSpeed = 10f; 
    protected float maxAngle = 10f;

    void Awake()
    {
        speed = new Vector3(0, 0, z_speed); 
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    protected void MoveLeft()
    {
        speed = new Vector3(-x_Speed / 2, 0f, z_speed);
    }

    protected void MoveRight()
    {
        speed = new Vector3(x_Speed / 2, 0f, z_speed);
    }
    protected void MoveFast()
    {
        z_speed += Time.fixedDeltaTime;
        if(z_speed >= 45f)
        {
            z_speed = 45f;
        }

    }

    protected void MoveSlow()
    {
        if (z_speed > 8f) {
        z_speed -= Time.fixedDeltaTime;
        }
        else
        {
            z_speed = min_z_speed;
        }

    }

    protected void MoveDuz()
    {
        speed = new Vector3(0f, 0f, z_speed);
    }

    protected void MoveNormal()
    {
        if(z_speed < 10f)
        {
            z_speed += Time.fixedDeltaTime;
            
        }
        else
        {
            z_speed -= Time.fixedDeltaTime;
        }
        
        
    }

    protected void ChangeSpeed()
    {
        
            if (z_speed < 10f)
            {
                z_speed += Time.fixedDeltaTime;
                speed = new Vector3(speed.x, speed.y, z_speed);
            }
            else
            {
                z_speed -= Time.fixedDeltaTime;
                speed = new Vector3(speed.x, speed.y, z_speed);
            }
        
    }



}
