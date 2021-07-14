using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    int delayInSeconds;
    [SerializeField]
    AudioSource loadingTheme;
    [SerializeField]
    int currentSceneIndex;

    /***
     *      Find our audio clip we are playing and save how long it takes to play.
     ***/
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {   // Play loading theme music and load the start scene after the music finishes
            loadingTheme = FindObjectOfType<AudioSource>();
            delayInSeconds = (int) (loadingTheme.clip.length + 0.999999f);    // Round up to a full second for the last fraction of a second.
            Debug.Log("Calling StartGame()");
            StartGame();
        }   // if
    }   // Start()

    /***
     *      Load the Starting Scene when we display our first frame.
     ***/
    void Update()
    {
    }   // Update()

    /***
     *      Delay for the length it takes for our sound clip to play and then load the Start Game scene.
     ***/
    private void StartGame()
	{
        StartCoroutine(WaitForTime(delayInSeconds));
    }   // StartGame()

    /***
     *      Delay for the number of seconds in the passed value.
     ***/
    IEnumerator WaitForTime(int delay)
    {
        Debug.Log("Delaying for " + delay + " seconds");
        yield return new WaitForSeconds(delay);
        Debug.Log("Calling LoadNextScene()");
        LoadNextScene();
    }   // WaitForTime()

    /***
     *      Load the next scene and bump the current scene index for next time.
     ***/
    public void LoadNextScene()
	{
        currentSceneIndex++;
        Debug.Log("New scene index will be: " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
	}   // LoadNextScene()
}   // class LevelLoader