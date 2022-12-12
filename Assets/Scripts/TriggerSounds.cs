using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSounds : MonoBehaviour
{
     public AudioSource SoundSource;
     public AudioClip Splat, Horay;
    // Start is called before the first frame update
   private void onTriggerEnter(Collider other)
   {
       // Debug.Log(other.tag);
       print("Collision Occurance");
       
    SoundSource.PlayOneShot(Horay, 1f);

        
        if(other.gameObject.CompareTag("HitFloor"))
        {
        SoundSource.PlayOneShot(Splat, 1f);
        }
   }
   private void onTriggerStay(Collider other)
   {
    print("STAYING");
   }
   private void onTriggerExit(Collider other)
   {
    print("exiting");
   }
}
