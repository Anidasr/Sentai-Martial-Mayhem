using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healthBonus = 50f;
    public float maxHealthBonus = 50f;
    public LayerMask playerLayer; 

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, playerLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Destroy(gameObject); 
            }
        }
    }
}
