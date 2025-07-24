using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    
    public float health; //Nyawa yang ditampilkan
    public int life; // banyak "life"
    public float maxHealth; //Bar hitam pada health bar, agar terlihat seperti terisi
    public Image healthUI; //Fill amount nyawa
    public GameObject[] healthUIImg; //life count apabila health sudah 0, life akan deactive
    public GameObject gameOverCanvas;

    //protected bool OnPlayerDeath; //ADD BOOLEAN
    public bool OnPlayerDeath=false;
    [SerializeField] private LayerMask medkitLayer;
    private Playermovement playerMovement;
    private enemy enemy;
    private VFXchara VFXchara;

    private void Update()
    {
        //Health Bar fill agar terlihat terisi
        healthUI.fillAmount = health / maxHealth;
        DetectCollision();
    }

    void Start()
    {
        // Get the Player_Health component
        playerMovement = GetComponent<Playermovement>();
    }

    public void TakeDamage(float damage)
    {
        // Pengurangan health player apabila terkena serangan
        if (!playerMovement.isGuarding)
        {
            health -= damage;
            GetComponentInChildren<Characteranimation>().Hit1(true);
            //Debug.Log($"<color=green>Player=</color>" + health);

            // Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
            if (health <= 0 && life >= 0)
            {
                healthUIImg[life].SetActive(false);
                life--;
                health += maxHealth;
            }
        }
        else
        {
            damage = 0;
            GetComponentInChildren<Characteranimation>().Hit1(false);
            Debug.Log("Sedang guarding");
            VFXchara = GameObject.Find("Player").GetComponent<VFXchara>();
            VFXchara.FXPunch3.GetComponent<ParticleSystem>().Play();
        }

        // Kalau Player mati sementara dia reload Scene
        if (life == -1)
        {
            Die();

            OnPlayerDeath = true;               //Player Die
            Invoke("ActivateGameOver", 2f);
        }
    } public void TakeDamageboss(float damage)
    {
        // Pengurangan health player apabila terkena serangan
        if (!playerMovement.isGuarding)
        {
            health -= damage;
            GetComponentInChildren<Characteranimation>().throwe();
            GetComponentInChildren<Characteranimation>().wakeup();


            // Apabila nyawa 0, life berkurang dan nyawa akan kembali penuh
            if (health <= 0 && life >= 0)
            {
                healthUIImg[life].SetActive(false);
                life--;
                health += maxHealth;
            }
        }
        else
        {
            damage = 0;
            GetComponentInChildren<Characteranimation>().Hit1(false);
            Debug.Log("Sedang guarding");
            VFXchara = GameObject.Find("Player").GetComponent<VFXchara>();
            VFXchara.FXPunch3.GetComponent<ParticleSystem>().Play();
        }

        // Kalau Player mati sementara dia reload Scene
        if (life == -1)
        {
            Die();

            OnPlayerDeath = true;               //Player Die
            Invoke("ActivateGameOver", 2f);
        }
    }

    void ActivateGameOver()
    {
        Debug.Log("Activating Game Over after 2 seconds");

        // Dead animation, Menu -> Active
        gameOverCanvas.SetActive(true);

        Debug.Log("Time.timeScale set to 0");
        Time.timeScale = 0;
    }

    void Die()
    {
        //Debug.Log("dead");
        health = 0;
        GetComponentInChildren<Characteranimation>().Hit1(false);
        // Memanggil metode Die pada Characteranimation
        GetComponentInChildren<Characteranimation>().Die();
    }

    private void DetectCollision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Medkit"))
            {
                Medkit medkit = collider.GetComponent<Medkit>();

                if (medkit != null)
                {
                    // Tambahkan health dan maxHealth dari Medkit
                    health += medkit.healthBonus;

                    // Batasi health dan maxHealth agar tidak lebih dari 100
                    health = Mathf.Min(health, 100f);

                    // Aktifkan kembali life UI jika health lebih besar dari 0
                    if (health > 0 && life < healthUIImg.Length)
                    {
                        healthUIImg[life].SetActive(true);
                    }

                    collider.gameObject.SetActive(false);
                }
            }
        }
    }


}
