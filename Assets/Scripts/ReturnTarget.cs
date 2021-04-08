using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTarget : MonoBehaviour
{
    //[SerializeField]
    //public Transform[] ReturnTargets;   
    //Collider RCollider;
    //MeshRenderer RMCollider;

    public static int Rcount = 0;
    public GameObject[] RTargetcube = new GameObject[9];
    private AudioSource RTargetSound;

    void Start()
    {
        RTargetSound = GetComponent<AudioSource>();
        //RCollider = GetComponent<Collider>();
        //RMCollider = GetComponent<MeshRenderer>();
    }
     
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.CompareTag("ttBall"))
        {            
            RTargetSound.Play();
          
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
            //Debug.Log("Rcount   " + Rcount);
            Rcount += 1;
            RTargetcube[Rcount].GetComponent<MeshRenderer>().enabled = true;
            RTargetcube[Rcount].GetComponent<Collider>().enabled = true;           
            
        }
    }
}
