using UnityEngine;
using System.Collections;

public class TopWall : MonoBehaviour {

    private Status status;



    // Use this for initialization
    void Start () {

        //dynamic assignments
        status = GameObject.FindObjectOfType<Status>();            

        }



    void OnCollisionEnter2D(Collision2D col) {


        status.HitHistory(3);   //update Hit History with id of hit object: 3 = Top Wall

        }






    }
