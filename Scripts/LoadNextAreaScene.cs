using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextAreaScene : MonoBehaviour {

    public string sceneName = string.Empty;
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D other) //needed to use the 2D version of OnTriggerEnter which is OnTriggerEnter2D as well as Collider2D to make it work 
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName); //load the scene taking a paramater of a string which will be the name of the scene to load
        }
    }
}
