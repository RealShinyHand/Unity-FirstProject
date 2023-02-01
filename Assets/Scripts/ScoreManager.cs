using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance = null;
    void Awake()
    {
        if(Instance == null)
        {
        Instance = this;
        }
    }

    public int currentScore = 0;
    public TMPro.TMP_Text currentScoreUi;
    private int bestScore = 0;
    public TMPro.TMP_Text bestScoreUi;

    public void UpdateSocore()
    {
        currentScore += 1;
        currentScoreUi.text = "Score : " + currentScore.ToString();

        Debug.Log(string.Format("현점 : {0} , 베점 : {1}", currentScore, bestScore));
        if(currentScore > bestScore)
        {
            updateBestScoreText(currentScore);
            PlayerPrefs.SetInt(nameof(bestScore), currentScore);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt(nameof(bestScore),0);
        updateBestScoreText(bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateBestScoreText(int value)
    {
        bestScore = value;
        bestScoreUi.text = "Best Score : " + value.ToString();
    }
}
