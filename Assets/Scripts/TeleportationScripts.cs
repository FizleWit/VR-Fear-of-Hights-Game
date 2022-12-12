using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationScripts : MonoBehaviour
{
    [SerializeField] GameObject HomeBaseTeleportation;
    
    public AudioClip Scream, Splat, Horay;
    Vector3 HomeBaseLocation;
    public AudioSource SoundSource;


    // Start is called before the first frame update
    void Start()
    {
        
        HomeBaseLocation = HomeBaseTeleportation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 playerLocation = gameObject.transform.position;
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TeleportPlayer(HomeBaseLocation);
        }
        //if y is above a certain limit (26) and z is above a certain limit (29)= made it to other side trigger something

        //if Y is below a certain limit( 10 ) teleport to home base
        if(transform.position.y <= 26f)
        {
            SoundSource.PlayOneShot(Scream, 1f);
        }
        if(transform.position.y <4f)
        {
            SoundSource.PlayOneShot(Splat,1f);
           // yield return new WaitForSeconds(3);
        }
         if( transform.position.y <= 2.3f)
         {
            //player falling
             TeleportPlayer(HomeBaseLocation);
         }
           
    }

    void TeleportPlayer(Vector3 tpLocation)
    {
        gameObject.transform.position = tpLocation;
        Debug.Log(tpLocation + " Teleport reached");
    }

   
}
