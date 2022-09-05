using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicSoundForbat : MonoBehaviour
{
    private AudioSource ticSound;
    // Start is called before the first frame update
    void Start()
    {
        ticSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit By  ------     " + this.gameObject);
        ticSound.Play();
    }
}
