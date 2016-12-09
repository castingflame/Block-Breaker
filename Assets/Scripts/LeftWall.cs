using UnityEngine;
using System.Collections;

public class LeftWall : MonoBehaviour {

    private Status status;


	// Use this for initialization
	void Start () {
        
        //dynamic assignments
        status = GameObject.FindObjectOfType<Status>();     

        
        }

   

    void OnCollisionEnter2D(Collision2D col) {


        status.HitHistory(4);   //update Hit History with id of hit object: 4 = Left Wall

        }

        
   
        }

//GitHub Test
//3rd Test
//4th Test
