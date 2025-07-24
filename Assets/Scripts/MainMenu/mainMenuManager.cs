using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public GameObject setting;
    public void Enter(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void Setting()
    {
        setting.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
