using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wincanvas : MonoBehaviour
{
    public GameObject WinUI;
    public ScriptScene scriptScene;

    private void Start()
    {
        WinUI.SetActive(false);
    }
    public void nextstage(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void Back(string key)
    {
        PlayerPrefs.SetInt(key, 1); //PlayerPrefs.SetInt(key, 1);
        scriptScene.PindahScene("StageSelection");
    }
}

