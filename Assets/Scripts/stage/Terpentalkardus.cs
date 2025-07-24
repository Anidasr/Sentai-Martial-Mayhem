using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terpentalkardus : MonoBehaviour
{
    public float kekuatanPental = 10.0f;
    public float rotasiPental = 5.0f;
    public float ambangBatasKecepatan = 5.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > kekuatanPental)
        {
            // Berikan gaya pentalan pada objek
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 arahPentalan = collision.contacts[0].point - transform.position;
                rb.AddForce(arahPentalan.normalized * kekuatanPental, ForceMode.Impulse);

                // Tentukan apakah objek hanya akan bergeser atau berputar
                if (collision.relativeVelocity.magnitude > ambangBatasKecepatan)
                {
                    // Berikan rotasi tambahan
                    rb.angularVelocity = Random.insideUnitSphere * rotasiPental;
                }
            }
        }
    }
}
