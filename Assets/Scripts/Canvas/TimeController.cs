using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public TextMeshProUGUI TimeText;
    public float TimeStage;
    public GameObject GameOverUI;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeStage *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        TimeStage -= Time.deltaTime;
        float minute = Mathf.FloorToInt(TimeStage / 60);
        float second = Mathf.FloorToInt(TimeStage % 60);

        TimeText.text = string.Format("{0,00}:{1,00}", minute, second);

        if (minute == 0 && second == 0)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
