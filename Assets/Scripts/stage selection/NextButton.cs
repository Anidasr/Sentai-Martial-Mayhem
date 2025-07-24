using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public ScriptScene scriptScene;

    void Update()
    {
        // Cek jika tombol "Tab" ditekan
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Panggil fungsi nextStage dengan kunci yang sesuai
            nextStage("Stage2");
            nextStage("StageBoss");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Kembali ke scene pemilihan stage
            scriptScene.PindahScene("StageSelection");
        }
    }

    public void nextStage(string key)
    {
        // Unlock Next Stage
        PlayerPrefs.SetInt(key, 1);
        scriptScene.PindahScene("StageSelection");
    }
}
