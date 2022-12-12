using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBatCar: MonoBehaviour 
{
   // Start is called before the first frame update
    public Vector3 offset;

    //public GameObject[] TraceBotPathArray;
    int startRotation;

    public Transform[] target;

    private int current;

    //for moving between points
    private float damping = 90.0f;
    //[SerializeField] float ddt =  6.0f;
    private float speed = 10.0f;

      //  void Update()
      // {
      // InvokeRepeating("TargetUpdate",1f,1f);

      // //Debug.Log(current);
      // } 

    void Update()
      { 
        //ddt = (float) Time.deltaTime;
        if (transform.position != target[current].position)
          {
            Vector3 pos = Vector3.MoveTowards(transform.position,target[current].position,speed);
              //Vector3 TargetPosition = new Vector3(target[current].position.x, transform.position.y, target[current].position.z);

              //Vector3 pos = Vector3.MoveTowards(transform.position,TargetPosition, speed);
            GetComponent<Rigidbody>().MovePosition(pos);

            //ROTATES CARS
            var rotation = Quaternion.LookRotation(target[current].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            //Debug.Log(Time.deltaTime);
          }
        else  
          {
            current = (current + 1) % target.Length;
            //transform.Rotate(0,90,0);
          }
        //Debug.Log(current);
      }
    //transform.LookAt(targetArray[current + 1].transform.position);
    // WaitForSeconds(2f) Destroy (Targeting);
}