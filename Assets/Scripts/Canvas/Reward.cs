using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField]
    public GameObject RewardCanvas;
    private Player_Health playerHealth;
    private PlayerAttack playerAttack;
    private Playermovement playerMovement;
    private TimeController timeController;


    private float speedIncreasePercentage = 0.1f;


    void Start()
    {
        // Dapatkan referensi Player_Health dari objek Player
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
    }
    public void increaseshp()
    {
        if (playerHealth != null)
        {
            // Tambahkan 50 health pada player
            playerHealth.health += 50;

            playerHealth.health = Mathf.Min(playerHealth.health, 100f);


            // Aktifkan kembali life UI jika health lebih besar dari 0
            if (playerHealth.health > 0 && playerHealth.life < playerHealth.healthUIImg.Length)
            {
                playerHealth.healthUIImg[playerHealth.life].SetActive(true);
            }
        }
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }


    public void increasesspeed()
    {
        if (playerMovement != null)
        {
            // Menambahkan 5% ke speed walk dan run
            playerMovement.walk_Speed += playerMovement.walk_Speed * speedIncreasePercentage;
            playerMovement.run_Speed += playerMovement.run_Speed * speedIncreasePercentage;
        }

        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void increasestime()
    {
        if (playerAttack != null)
        {
            // Menambahkan 10% ke damage ultimate
            playerAttack.DamageValue.ultimate += (int)(playerAttack.DamageValue.ultimate * 0.1f);
        }

        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void increasesspecialDMG()
    {
        if (playerAttack != null)
        {
            // Menambahkan 20% ke SPpunchValue dan SpKickValue
            playerAttack.DamageValue.SpPunchValue += (int)(playerAttack.DamageValue.SpPunchValue * 0.2f);
            playerAttack.DamageValue.SpKickValue += (int)(playerAttack.DamageValue.SpKickValue * 0.2f);
        }
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void increasesDMG()
    {
        if (playerAttack != null)
        {
            // Menambahkan 20% ke punch1Value, punch2Value, punch3Value, kick1Value, kick2Value, dan kick3Value
            playerAttack.DamageValue.punch1Value += (int)(playerAttack.DamageValue.punch1Value * 0.2f);
            playerAttack.DamageValue.punch2Value += (int)(playerAttack.DamageValue.punch2Value * 0.2f);
            playerAttack.DamageValue.punch3Value += (int)(playerAttack.DamageValue.punch3Value * 0.2f);
            playerAttack.DamageValue.kick1Value += (int)(playerAttack.DamageValue.kick1Value * 0.2f);
            playerAttack.DamageValue.kick2Value += (int)(playerAttack.DamageValue.kick2Value * 0.2f);
            playerAttack.DamageValue.kick3Value += (int)(playerAttack.DamageValue.kick3Value * 0.2f);
        }
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Skipreward()
    {
        RewardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
