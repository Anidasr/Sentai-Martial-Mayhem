using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahFloorTrigger : MonoBehaviour
{

    public float targetX; // Variable untuk posisi X target
    public float targetY; // Variable untuk posisi Y target
    public float targetZ; // Variable untuk posisi Z target
    public GameObject RewardUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Dapatkan objek pemain
            GameObject player = other.gameObject;

            // Pindahkan pemain ke posisi yang ditentukan
            player.transform.position = new Vector3(targetX, targetY, targetZ);

            Time.timeScale = 0;

            RewardUI.SetActive(true);
        }
    }
}
