using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private float ballGrav = 0;
    private Ball theBall;
   

   

    // Use this for initialization
    void Start () {

        theBall = GameObject.FindObjectOfType<Ball>();

        GetComponent<Rigidbody2D>().gravityScale = 1;    //sets the initial ball gravity to 1

        paddle = GameObject.FindObjectOfType<Paddle>();  //dynamically assigns paddle to the ball script
        paddleToBallVector = this.transform.position - paddle.transform.position; //pin the ball to the paddle at game start 
       
        }//start -end

    
    // Update is called once per frame
    void Update(){

        if (!hasStarted){
            //Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

                //Wait for a mouse click to launch theball
                if (Input.GetMouseButtonDown(0)){
                    hasStarted = true;          //Set the game start flag
                    GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);

                }

            }
        
        }//Update -end


    void OnCollisionEnter2D(Collision2D collision){

        Vector2 tweak = new Vector3(Random.Range(0,0.5f), Random.Range(0, 0.5f)); //creates a small random vector to be added to the balls
                                                                                  //trajectory to stop the ball becoming 'stuck'.
        
        if (hasStarted){ //only make the sound after the ball has been released

            GetComponent<AudioSource>().Play(); //replaces the depreciated  audio.Play();
            GetComponent<Rigidbody2D>().velocity += tweak; //adds some randomness to our ball velocity to stop getting 'stuck' 

            }

        }//OnCollisionEnter2D -end


    
    public void IncreaseBallGravity(){

        ballGrav = theBall.GetComponent<Rigidbody2D>().gravityScale;        //get gravity value and assign it to ballGrav
        ballGrav++;                                                         //increment ballGrav
        theBall.GetComponent<Rigidbody2D>().gravityScale = ballGrav;        //assign ballGrav to the balls gravity


        }// IncreaseBallGravity -end


    }
