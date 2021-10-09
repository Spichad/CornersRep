using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayAgain : MonoBehaviour
{
public void Restart()
    {
        // Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    } 
}
