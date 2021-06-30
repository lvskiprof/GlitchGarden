using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    float delayInSeconds;
    AudioSource loadingTheme;

    /***
     *      Find our audio clip we are playing and save how long it takes to play.
     ***/
    void Start()
    {
        loadingTheme = FindObjectOfType<AudioSource>();
        delayInSeconds = loadingTheme.clip.length;
    }   // Start()

    /***
     *      Load the Starting Scene when we display our first frame.
     ***/
    void Update()
    {
        StartGame();
    }   // Update()

    /***
     *      Delay for the length it takes for our sound clip to play and then load the Start Game scene.
     ***/
    private IEnumerable StartGame()
	{
        yield return StartCoroutine(WaitToLoad());
        SceneManager.LoadScene("StartScreen");
    }   // StartGame()

    /***
     *      Delay for the length it takes for our sound clip to play.
     ***/
    private IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
    }   // WaitToLoad()
}   // class LoadGame