using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public void pauseGame(){
        Time.timeScale = 0;
    }
    public void resumeGame(){
        Time.timeScale = 1;
    }
    public void goMainMenu(){
        Time.timeScale = 1;
        ScoreTracker.totalScore = 0;
        SceneManager.LoadScene("Menu");
    }
}
