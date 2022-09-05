using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    GameObject Tball;
    public GameObject spawnpoint;

    void Start()
    {
        Tball = Resources.Load("TennisBall") as GameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ttBall")) 
            {
            //Destroying TTball when it touch ground
              Destroy(collision.gameObject);
              destroyBall();
            }        
     }
    void destroyBall()
    {       
        //Debug.Log("inside Destroyball.cs, going to destroy  : " + collision.gameObject);

        //Instanciating new TT ball below Table  //if you need a ball under table write <2
        if (GameObject.FindGameObjectsWithTag("ttBall").Length < 2)
        {
            GameObject spawner = Instantiate(Tball) as GameObject;
            spawner.transform.position = spawnpoint.transform.position;

            //add mesh collider of forehand  bat for a sec
         //   GameObject GoForeHandBat = GameObject.FindGameObjectWithTag("ForeHandBat");
         //   GoForeHandBat.GetComponent<MeshCollider>().enabled = true;
        }
    }  
   
}
