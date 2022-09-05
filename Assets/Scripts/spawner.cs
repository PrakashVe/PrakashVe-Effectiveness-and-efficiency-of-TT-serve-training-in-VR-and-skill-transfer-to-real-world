using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform Sphere;
    public GameObject SpherePrefab;
    GameObject G1;


    void Start()
    {
       

        StartCoroutine(AutoThrow());
    }

    // Update is called once per frame
    void Yo()
    {
        G1=Instantiate(SpherePrefab, Sphere.position, Quaternion.identity);
        Destroy(G1, 3f);
        
    }


    IEnumerator AutoThrow()
    {
        Yo();
        yield return new WaitForSeconds(3);//wait for 2 second
        StartCoroutine(AutoThrow());
    }


}
