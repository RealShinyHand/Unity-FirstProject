using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public TMPro.TMP_Text currentScoreUi;
    private int bestScore = 0;
    public TMPro.TMP_Text bestScoreUi;

    public void updateSocore()
    {
        currentScore += 1;
        currentScoreUi.text = "Score : " + currentScore.ToString();

        if(currentScore > bestScore)
        {
            bestScoreUi.text = "Best Score : " + currentScore.ToString();
            PlayerPrefs.SetInt(nameof(bestScore), currentScore);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt(nameof(bestScore),0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
