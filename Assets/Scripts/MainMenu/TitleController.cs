using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameObject Continue;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(Blink());
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            Continue.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            Continue.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
