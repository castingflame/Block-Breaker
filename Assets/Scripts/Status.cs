using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Status : MonoBehaviour {

   //game objects
    private Text scoreText;
    private Text highText;
    private Text livesText;
    private Text levelText;
    private Ball ball;

    //score 
    private int scoreCount = 0;      //score counter total

    

    void Start () {
              

        //Dynamically get objects and assign a handle
        scoreText = GameObject.Find("Score").GetComponent<Text>();          
        highText = GameObject.Find("HighScore").GetComponent<Text>();
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        levelText = GameObject.Find("Level").GetComponent<Text>();
        ball = GameObject.FindObjectOfType<Ball>();

        


        }

    // Update is called once per frame
    void Update () {

        //scoreText.text = ball.transform.position.x.ToString();
        //highText.text  = ball.transform.position.y.ToString();
        //livesText.text = ball.transform.position.x.ToString();
        //levelText.text = ball.transform.position.y.ToString();
        
        }
    


    public void Score() {                       

        scoreCount++;                                   //increment score
        scoreText.text = scoreCount.ToString();         //display score

        }



    void HighScore() {


        }


    void Lives() {


        }

    void Level() {


        }



    }
