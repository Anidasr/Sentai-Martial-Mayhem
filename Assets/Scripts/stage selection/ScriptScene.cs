using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptScene : MonoBehaviour
{
    public TextMeshProUGUI FinalScore, FinalTime;
    public GameObject WinUI;
    public GameObject[] locks;
    public bool isFinished;
    public GameObject gembok;

    private GameData gameData;

    private void Start()
    {
        if (WinUI != null)
        {
            WinUI.SetActive(false);
        }
        isFinished = false;

        CheckAndSetLocks();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFinished)
        {
            Continue("Stage2");
            Continue("Stage3");
            Continue("Stage4");
            Continue("Stage5");
        }

        if (FinalScore != null && FinalTime != null)
        {
            ShowScore();
            ShowTime();
        }
    }

    public void PindahScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void ShowScore()
    {
        if (ScoreController.singleton != null)
        {
            FinalScore.text = ScoreController.singleton.GetTotalPoint().ToString();
        }
    }

    public void ShowTime()
    {
        if (TimeController.instance != null)
        {
            float TimeNow = TimeController.instance.TimeStage;
            float minute = Mathf.FloorToInt(TimeNow / 60);
            float second = Mathf.FloorToInt(TimeNow % 60);

            FinalTime.text = string.Format("{0,00}:{1,00}", minute, second);

            if (minute == 0)
            {
                FinalTime.text = second + " Detik";
            }
        }
    }

    public void Finish()
    {
        Time.timeScale = 0;
        if (WinUI != null)
        {
            WinUI.SetActive(true);
        }
        isFinished = true;
    }

    public void Continue(string key)
    {
        PlayerPrefs.SetInt(key, 1);
        SceneManager.LoadScene("StageSelection");
        CheckAndSetLocks();
    }

    public void back1()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void back2()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    // Metode untuk memeriksa dan mengatur status gembok
    bool IsStage2Unlocked()
    {
        return PlayerPrefs.GetInt("Stage2", 0) == 1;
    }

    void CheckAndSetLocks()
    {
        if (locks != null)
        {
            for (int i = 0; i < locks.Length; i++)
            {
                string stageKey = "Stage" + (i + 2);
                if (PlayerPrefs.GetInt(stageKey, 0) == 1)
                {
                    if (locks[i] != null)
                    {
                        locks[i].SetActive(false);
                    }
                    if (IsStage2Unlocked())
                    {
                        DisableGembok();
                    }
                }
            }
        }
    }

    void DisableGembok()
    {
        if (gembok != null)
        {
            gembok.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        if (data != null)
        {
            FinalScore.text = data.finalScore.ToString();
            FinalTime.text = data.finalTime.ToString(); // Load waktu dari GameData
        }
    }

    private void SaveData(ref GameData data)
    {
        if (data != null)
        {
            float score = 0;
            float.TryParse(FinalScore.text, out score);
            data.finalScore = score;

            float time = 0;
            float.TryParse(FinalTime.text.Replace(" Detik", ""), out time);
            data.finalTime = time; // Simpan waktu ke dalam GameData
        }
    }

    // Metode untuk memuat scene in-game berdasarkan karakter yang dipilih
    public void LoadCharacterScene()
    {
        string selectedScene = PlayerPrefs.GetString("SelectedCharacterScene", "coba"); // Default ke "coba"
        SceneManager.LoadScene(selectedScene);
    }
}
