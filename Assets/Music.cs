using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music _instance;

    public static Music Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Music>();
                if (_instance == null)
                {
                    GameObject musicGameObject = new GameObject("Music");
                    _instance = musicGameObject.AddComponent<Music>();
                    DontDestroyOnLoad(musicGameObject);
                }
            }
            return _instance;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>(); // Asumsikan pemutar musik menggunakan AudioSource
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Memanggil method OnSceneLoaded saat scene berpindah
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 4) // Pastikan indeks scene keempat sesuai dengan indeks scene yang dimaksud
        {
            StopMusic();
        }
        else
        {
            PlayMusic("NamaLagu"); // Ganti dengan kode untuk memulai musik di scene lain
        }
    }


    public void PlayMusic(string musicName)
    {
        Debug.Log("Memulai musik: " + musicName);
        // Kode untuk memulai musik dengan nama tertentu
    }

    public void StopMusic()
    {
        if (audioSource != null)
        {
            Debug.Log("Menghentikan musik");
            audioSource.Stop();
        }
    }

}
