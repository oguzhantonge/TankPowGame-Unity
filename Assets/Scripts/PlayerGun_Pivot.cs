using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun_Pivot : MonoBehaviour
{
    public static PlayerGun_Pivot instance;

    public Transform Tower;
    public float towerSpeed;
    public float TowerAngle;

    void Awake()
    {
     if(instance == null)
        {
            instance = this;
        }   
    }
   
    void Update()
    {
      //RotateCannon();
       RotateTower();
       
    }

    void RotateTower()
    {
        
        TowerAngle += Input.GetAxis("Mouse X") * towerSpeed * Time.deltaTime;
        TowerAngle = Mathf.Clamp(TowerAngle, -50, 50);
        Tower.localRotation = Quaternion.AngleAxis(TowerAngle,new Vector3(0,0,1)); // z axis ile sağa sola çevirme
       
    }
    
    





}//class








