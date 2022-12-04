using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScoreDisplay : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = ScoreTracker.plrName+"'s Score: "+ScoreTracker.totalScore.ToString();
    }
}
