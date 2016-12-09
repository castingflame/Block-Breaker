using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
public int myNewLevel = 0;


    public void LoadLevel(string name)

        {
        Brick.breakableCount = 0;    //reset the brick qty counter before loading a level
        SceneManager.LoadScene(name);
        }



    public void LoadNextLevel()
        {

        //obolete code:
        //Application.LoadLevel(Application.loadedLevel + 1);

        //my version of the above

        Brick.breakableCount = 0;    //reset the brick qty counter before loading a level
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int newScene = currentScene +1;
        SceneManager.LoadScene(newScene);
        
        
        }


    public void BrickDestroyed()
        {
        if (Brick.breakableCount <= 0)
            {
            LoadNextLevel();
            }

        }


    public void QuitGame()
    {
     
        Application.Quit();
    }



}
