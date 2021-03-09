using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilindirScript : MonoBehaviour
{

    Rigidbody body;

    private Text silindirSpeedText;
    private Text minSilindirSpeedText;
    private float silindir_speed;
    private float minSilindir_speed;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        silindirSpeedText = GameObject.Find("SilindirSpeedText").GetComponent<Text>();
        minSilindirSpeedText = GameObject.Find("MinSilindirSpeedText").GetComponent<Text>();
    }
     void Start()
    {
        silindir_speed = PlayerMovement.instance.speed.z;
        minSilindir_speed = PlayerMovement.instance.speed.z;
        StartCoroutine("IncreaseSpeedSilindir");
    }

    // Update is called once per frame
    void Update()
    {
        CheckSilindirSpeed();

        transform.GetChild(0).transform.Rotate(new Vector3(0f, -15f, 0f) * Time.fixedDeltaTime);
        body.MovePosition(transform.position + new Vector3(0f, 0f,silindir_speed) * Time.fixedDeltaTime);




        if (silindir_speed >= 45f)
        {
            silindir_speed = 45f;
            silindirSpeedText.text = "Silindir Speed(MAX) -> " + Mathf.Round(silindir_speed);

        }
        else
        {
            silindirSpeedText.text = "Silindir Speed -> " + Mathf.Round(silindir_speed);
        }
        minSilindirSpeedText.text = "Silidir Speed(Min) -> " + Mathf.Round(minSilindir_speed);
      

        CheckPosition();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }

    }

    void CheckPosition()
    {
        if(transform.position.z < PlayerMovement.instance.transform.position.z - 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, PlayerMovement.instance.transform.position.z -4f);
        }
    }

    IEnumerator IncreaseSpeedSilindir()
    {
        yield return new WaitForSeconds(1f);
        if (minSilindir_speed < 45)
        {
        minSilindir_speed++;
        }
        
        StartCoroutine("IncreaseSpeedSilindir");
    }
    void CheckSilindirSpeed()
    {
        if(silindir_speed<= minSilindir_speed)
        {
            silindir_speed = minSilindir_speed;
        }
        if(PlayerMovement.instance.speed.z > minSilindir_speed)
        {
            silindir_speed = PlayerMovement.instance.speed.z;
        }
    }
}
