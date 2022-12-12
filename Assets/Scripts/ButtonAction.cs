using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonAction : MonoBehaviour
{
  [System.Serializable]
    public class ButtonEvent : UnityEvent { }
    [SerializeField] GameObject PlayerVR;
    GameObject PlayerGameObject;
    [SerializeField] GameObject HomeBaseTeleportation;
    Vector3 HomeBaseLocation;

    public float pressLength;
    public bool pressed;
    public ButtonEvent downEvent;
    AudioSource audio;
    Vector3 startPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PlayerGameObject = PlayerVR;
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        HomeBaseLocation = HomeBaseTeleportation.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
         // If our distance is greater than what we specified as a press
        // set it to our max distance and register a press if we haven't already
        float distance = Mathf.Abs(transform.position.y - startPos.y);
        if (distance >= pressLength)
        {
            // Prevent the button from going past the pressLength
            transform.position = new Vector3(transform.position.x, startPos.y - pressLength, transform.position.z);
            if (!pressed)
            {
                pressed = true;
                // If we have an event, invoke it
                downEvent?.Invoke();//run debutg line
                
                //TeleportPlayer(HomeBaseLocation);
                audio.PlayOneShot(audio.clip, 10f);

            }
        } else
        {
            // If we aren't all the way down, reset our press
            pressed = false;
        }
        // Prevent button from springing back up past its original position
        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
        void TeleportPlayer(Vector3 tpLocation)
    {
        PlayerGameObject.transform.position = tpLocation;
      //  Debug.Log(" Teleport reached xxxxxx ");
    }
}



