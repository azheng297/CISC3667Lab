using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public static int totalScore = 0;
    public static string plrName = "";
    [SerializeField] Text ScoreText;
    [SerializeField] InputField nameInputField;
    [SerializeField] int nextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: "+ScoreTracker.totalScore.ToString();
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Target").Length < 1){
            nextStage();
        }
    }

    public void addScore(){
        totalScore++;
        updateScore();
    }
    public void addScore(int val){
        totalScore = totalScore + val;
        updateScore();
    }
    void updateScore(){
        ScoreText.text = "Score: " + totalScore.ToString();
    }
    void nextStage(){
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void submitName(){
        plrName = nameInputField.text;
        nextStage();
    }
}
