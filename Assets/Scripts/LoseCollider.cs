using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void Start()
        {
        //dynamically assigns LevelManager to the lose colider script
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        }


    void OnTriggerEnter2D (Collider2D trigger)
    {

        
        levelManager.LoadLevel("Lose");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

    }

}
