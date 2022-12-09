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
  public float speed;
  private int current;
//  void Update()
// {
// InvokeRepeating("TargetUpdate",1f,1f);

// //Debug.Log(current);
// } 
  void Update()
{
 
  if (transform.position != target[current].position)
        {

          Vector3 pos = Vector3.MoveTowards(transform.position,target[current].position,speed );

          GetComponent<Rigidbody>().MovePosition(pos);
           
        }
        else  current = (current + 1) % target.Length;
        
        Debug.Log(current);
        }
 //transform.LookAt(targetArray[current + 1].transform.position);
          // WaitForSeconds(2f) Destroy (Targeting);
}