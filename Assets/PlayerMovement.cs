using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : ControllerScript
{
    public static PlayerMovement instance;
    public Transform silah;


    private Rigidbody myBody;


    public GameObject bulletPrefab;


    public Transform bulletSpawner;

    [SerializeField]
    private GameObject deathPanel;

    private Text mySpeedText;


    void Awake()
    {
        mySpeedText = GameObject.Find("MySpeedText").GetComponent<Text>();
        myBody = GetComponent<Rigidbody>();

        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }
    
    void Update()
    {

       // print(speed);
        MovementKeyboard();
        speed = new Vector3(speed.x, speed.y, z_speed);
        // print(Time.fixedDeltaTime);
        //print(z_speed);
      //  print("speed : " + speed.z);

        if (is_speed)
        {
            ChangeSpeed();
        }

        ChangeRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (speed.z >= 45f)
        {
            mySpeedText.text = "My Speed(MAX) -> " + Mathf.Round(speed.z);

        }
        else
        {
            mySpeedText.text = "My Speed -> " + Mathf.Round(speed.z);
        }
            // print(silah.forward.normalized);

    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        myBody.MovePosition(transform.position + (speed * Time.fixedDeltaTime));
    }



    void MovementKeyboard()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveFast();
            is_speed = false;
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveSlow();
            is_speed = false;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveNormal();
            is_speed = true;
           
        }
        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveNormal();
            is_speed = true;
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveDuz();
            
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveDuz();
            
        }
    }


    void ChangeRotation()
    {
        if(speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.Euler(0, PlayerGun_Pivot.instance.TowerAngle, 0f));
        bullet.GetComponent<BulletScript>().Move(z_speed *300f);

        //print(PlayerGun_Pivot.instance.TowerAngle);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
        
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "SilindirObstacle")
        {
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
        }
    }


} // class





































