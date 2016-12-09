using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;             //create an empty sprite array called hitSprites.
    public static int breakableCount = 0;   //create a counter for the qty of breakable bricks
    public AudioClip Hit;                   //
    public GameObject smoke;                //
    public Ball myBall;                     //


    private int timesHit;                   //variable to hold a running count for each bricks hits.  
    private LevelManager levelManager;      //
   
    private bool isBreakable;               //Flag for breakable bricks.
    private Status status;                  //declare status


    // Use this for initialization
    void Start ()
        {

        //dynamic assignments
        levelManager = GameObject.FindObjectOfType<LevelManager>();     //LevelManager
        myBall = GameObject.FindObjectOfType<Ball>();                   //Ball
        status = GameObject.FindObjectOfType<Status>();                 //Status


        timesHit = 0;                                       //Resets the bricks hit count.
        isBreakable = (this.tag == "Breakable");            //If the bricks tag says 'Breakable' our 
                                                            //'isBreakable' flag is set to true.
       
        
        //Breakable bricks
        if (isBreakable){                                   //Keep track of breakable bricks
            breakableCount++;                               //Increment the breakable brick counter 
            } 
 
        }//Start -end
	
	

    void OnCollisionEnter2D (Collision2D col){

        AudioSource.PlayClipAtPoint(Hit, transform.position);   //Plays the 'Hit' audio file dropped into
                                                                //the Inspector at the location of the brick.

        status.Score();                 //update the score
        if (isBreakable)                //Is the brick breakable?
                {
                 HandleHits();          //If breakble brick deal with it.
                 }
        }




    void HandleHits(){                          //Deal with a breakable brick

        timesHit++;                             //Increment the brick hit count.
        int maxHits = hitSprites.Length + 1;    //Use the brick image array to work out how many
                                                //max hits the brick will have.
                                                //NOTE: A +1 is needed as the array counts from 0 not 1.


        if (timesHit >= maxHits){           //Should the brick be destroyed?
            breakableCount--;               //Decrement qty of breakable bricks.
            levelManager.BrickDestroyed();  //Ask levelmanager to see if all the bricks have
                                            //been destroyed then manage the situation.
            PuffSmoke();                    //Put smoke on the destroyed brick.

            Destroy(gameObject);            //Destroy the brick instance.
            }
        else                                //Brick damaged but not destroyed.
            {
            LoadSprites();                  //Load the next damaged brick sprite.
            }
        }//HandleHits -end



    void PuffSmoke()            //Create the smoke
        {

        //Create a new instance of the smoke in the location of the brick & name it 'smokePuff'.
        GameObject smokePuff = Instantiate(smoke, transform.position, transform.rotation) as GameObject;

        //Set the colour of the smoke instance called 'smokePuff' to the same as the brick colour.
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

        //Destroy The Extinguished Smoke Instance
        //---------------------------------------
        //Create a variable 'smokeLife' to hold the length of time the smoke will be visible. 
        float smokeLife = smokePuff.GetComponent<ParticleSystem>().duration + smokePuff.GetComponent<ParticleSystem>().startLifetime;
        //Destroy the 'smokePuff' instance after it has finished its animation. 
        Destroy(smokePuff, smokeLife);


        //PROTOTYPE: PLAYING WITH GRAVITY

        //myBall.IncreaseBallGravity();
        
        }   //PuffSmoke() -end



    void LoadSprites()
        {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
            {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
        else
            {
            Debug.LogError("You have not put a sprite on the brick!");
            }

        }

    
    
    // TODO Remove this method when we can actually win
    void SimulateWin() {
        levelManager.LoadNextLevel();
        }





}
