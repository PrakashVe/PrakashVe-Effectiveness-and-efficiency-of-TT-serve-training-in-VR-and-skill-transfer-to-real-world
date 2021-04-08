using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// Can fall sound and Score Board
/// </summary>

public class Canfallsound : MonoBehaviour
{
    private AudioSource tCanFall;
    public TextMeshPro ScoreCounter;
    public static int scoreValue =0;
    
    void Start()
    {
        tCanFall = GetComponent<AudioSource>();       
        //ScoreCounter = GetComponent<TextMeshPro>();
        //ScoreCounter.text = "Hello";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ttBall" ) || collision.collider.CompareTag("Floor") )
        {
            tCanFall.Play();
            StartCoroutine(DisableCan());                           
        }
    }

    IEnumerator DisableCan()
    {
        yield return new WaitForSeconds(2);//wait for 2 second
        scoreValue += 1; //add 1 to score
        ScoreCounter.text = scoreValue.ToString(); //convert score to string
        this.gameObject.SetActive(false);// disable the can
    }
}
