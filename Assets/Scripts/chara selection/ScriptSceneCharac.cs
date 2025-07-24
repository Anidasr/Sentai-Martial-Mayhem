using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptSceneCharac : MonoBehaviour
{
    public KeyCode backButtonKey = KeyCode.Escape;
    public Button[] characterButtons;
    private int selectedCharacterIndex = -1;

    // Nama scene in-game untuk karakter pertama dan kedua
    public string[] characterGameScenes = new string[] { "coba", "Sceen2" };

    void Start()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", -1);
        UpdateCharacterSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(backButtonKey))
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }

    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        PlayerPrefs.SetString("SelectedCharacterScene", characterGameScenes[index]); // Simpan nama scene
        UpdateCharacterSelection();
        Debug.Log($"Karakter {index} dipilih: {characterGameScenes[index]}");
    }

    public void GoToStageSelection()
    {
        if (selectedCharacterIndex == -1)
        {
            Debug.LogWarning("Silakan pilih karakter terlebih dahulu!");
            return;
        }
        SceneManager.LoadScene("StageSelection");
    }

    private void UpdateCharacterSelection()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            // Tombol karakter harus selalu dapat diklik
            characterButtons[i].interactable = true;
        }
    }
}
