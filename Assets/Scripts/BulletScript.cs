using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rigid;

   
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();       
    }

    public void Move(float speed )
    {
        rigid.AddForce(transform.forward.normalized * speed);
        Invoke("YokEt",0.6f);
     //  print(transform.forward);
       // print(transform.forward.normalized);
       
    }


    private void YokEt()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Obstacle")
        {
            Destroy(target.gameObject);
        }
    }


}
