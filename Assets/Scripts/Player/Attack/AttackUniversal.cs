using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    private int numHit = 0;
    public int hitCount;
    public bool isEnemyBlock = false;

    public GameObject TanganKanan;
    public GameObject TanganKiri;
    public GameObject KakiKanan;
    public GameObject KakiKiri;

    //public float punchForcebiasa = 20f;
    //public float kickForcebiasa = 20f;
    //public float punchForcespecial = 50f;
    //public float kickForcespecial = 50f;


    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void DetectCollision_1()
    {
        Collider tangankananCollider = TanganKanan.GetComponent<Collider>();

        if (tangankananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankananCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 0.3f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }
    public void DetectCollision_2()
    {
        Collider tangankiriCollider = TanganKiri.GetComponent<Collider>();

        if (tangankiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankiriCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 0.3f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }
    public void DetectCollision_3()
    {
        Collider kakikananCollider = KakiKanan.GetComponent<Collider>();

        if (kakikananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(kakikananCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 0.3f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }
    public void DetectCollision_4()
    {
        Collider kakikiriCollider = KakiKiri.GetComponent<Collider>();

        if (kakikiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(kakikiriCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 0.3f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }

    public void DetectCollision_punch3()
    {
        Collider tangankiriCollider = TanganKiri.GetComponent<Collider>();

        if (tangankiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankiriCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }

                        // Posisi terpental musuh (contoh: mundur dari pemukulan)
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 1.0f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }



    public void DetectCollision_Kick3()
    {
        Collider kakikiriCollider = KakiKiri.GetComponent<Collider>();

        if (kakikiriCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(kakikiriCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);

                        // Geser posisi objek musuh untuk memberikan efek terpental
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance = 1.0f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;

                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }

    public void DetectCollision_parry()
    {
        Collider tangankananCollider = TanganKanan.GetComponent<Collider>();

        if (tangankananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankananCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.up;
                        float kickDistance = 1f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }

    public void DetectCollision_SP()
    {
        Collider tangankananCollider = TanganKanan.GetComponent<Collider>();

        if (tangankananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankananCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance =12f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }public void DetectCollision_Ulti()
    {
        Collider tangankananCollider = TanganKanan.GetComponent<Collider>();

        if (tangankananCollider != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(tangankananCollider.transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    // Ambil komponen 'enemy' dari objek musuh yang terkena pukulan
                    enemy enemyComponent = col.GetComponent<enemy>();
                    if (enemyComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen enemy
                        enemyComponent.TakeDamage((int)damage);
                        numHit++;
                        if (numHit >= hitCount)
                        {
                            isEnemyBlock = true;
                        }
                        else { isEnemyBlock = false; }
                        Vector3 kickDirection = -col.transform.forward;
                        float kickDistance =20f; // Jarak mundur dari pemukulan
                        col.transform.position += kickDirection * kickDistance;
                    }
                }
                else if (col.CompareTag("MiniBoss"))
                {
                    // Ambil komponen 'MB_health' dari objek musuh yang terkena pukulan
                    MB_health enemyBossComponent = col.GetComponent<MB_health>();
                    if (enemyBossComponent != null)
                    {
                        // Panggil metode TakeDamage pada komponen MiniBoss
                        enemyBossComponent.TakeDamage((int)damage);
                    }
                }
            }
        }
    }


}
