using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController singleton;

    public TextMeshProUGUI ScoreText;
    public float TotalScore;

    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
        TotalScore = 0;
        ScoreText.text = TotalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = TotalScore.ToString();
    }

    public void GetPoints(float score)
    {
        TotalScore += score;
    }

    public float GetTotalPoint()
    {
        return TotalScore;
    }
}
