using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    private LineRenderer lr;


    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider.gameObject.tag != "Bullet")
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                print(hit.distance);
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
        }


    }
}
