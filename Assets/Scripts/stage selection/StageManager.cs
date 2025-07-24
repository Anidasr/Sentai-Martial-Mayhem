using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Button buttonStage2;
    public Button buttonStage3;
    public GameObject quit;
    public GameObject gembok;

    void Start()
    {
        CheckStage();
        CheckAndDisableGembok();

    }

    public void SelectStage(int stageIndex)
    {
        // Ganti "YourGameplayScene" dengan nama scene permainan yang sesuai
        SceneManager.LoadScene("CharacterSelection");
    }

    public void CheckStage()
    {
        int statusStage2 = PlayerPrefs.GetInt("Stage2");
        int statusStage3 = PlayerPrefs.GetInt("StageBoss");

        if (statusStage2 == 1)
            buttonStage2.interactable = true;
        else
            buttonStage2.interactable = false;

        if (statusStage3 == 1)
            buttonStage3.interactable = true;
        else
            buttonStage3.interactable = false;
    }

    public void ResetStage()
    {
        PlayerPrefs.DeleteAll();
    }

    public void PreparingSave()
    {
        if (PlayerPrefs.HasKey("Stage2") == false)
        {
            PlayerPrefs.SetInt("Stage2", 1);
            PlayerPrefs.SetInt("StageBoss", 0);
        }
    }

    public void keluar()
    {
        quit.SetActive(true);
    }

    public void kembali()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    void CheckAndDisableGembok()
    {
        if (buttonStage2.interactable && gembok != null)
        {
            gembok.SetActive(false);
        }
        else
        {
            gembok.SetActive(true);
        }
    }

    //Stage2
    //StageBoss
    //1 == Unlock
    //0 == Lock
}