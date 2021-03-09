using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubePivotDistance;
    Vector3 cubesPivot;

    public float explosionForce;
    public float explosionRadius;
    public float explosionUpward;

    void Start()
    {
        cubePivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            explode();

        }
    }

    public void explode()
    {
        /// 5x5x5 pieces in x,y,z coordinates
        for(int x = 0; x < cubesInRow; x++)
        {
            for(int y = 0; y < cubesInRow; y++)
            {
                for(int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);

                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);

            }
        }
    }

    void createPiece(int x,int y,int z)
    {
        // create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //parçanın boyutunu ayarladık
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        // rigidbody ekledik
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

      //  piece.AddComponent<MeshRenderer>();
        //piece.GetComponent<MeshRenderer>().material = Color.red;

    }
}
