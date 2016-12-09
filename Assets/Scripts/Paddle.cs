using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float paddleLeftEdge;
    public float paddleRightEdge;



    private Ball ball;



    void Start()
        {
        ball = GameObject.FindObjectOfType<Ball>();  //find the Ball object and assign it to the ball variable
        }
	



	// Update is called once per frame
	void Update () {

        if (!autoPlay)
            {
            MoveWIthMouse();
            }
        else
            {
            AutoPlay();
            }



        }


    void MoveWIthMouse()

        {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f); //
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 8;   //
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, paddleLeftEdge, paddleRightEdge);
        this.transform.position = paddlePos;
        }


    void AutoPlay()
        {

        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f); //create a vetor for the paddle called paddlePos 
        Vector3 ballPos = ball.transform.position;          //create a vector for the moving ball called ballPos
        paddlePos.x = Mathf.Clamp(ballPos.x, paddleLeftEdge, paddleRightEdge);  //make the paddle x pos the same as the ball x pos (clamped to our play area)
        this.transform.position = paddlePos;    //apply the variable to make our position move
        
         }


    }


