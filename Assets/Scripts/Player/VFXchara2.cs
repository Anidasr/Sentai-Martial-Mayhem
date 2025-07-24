using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXchara2 : MonoBehaviour
{
    public GameObject fxbomb;
    public GameObject fxulti;
    public GameObject fxultibomb;
    public GameObject fxulti2;

    public void ONfxbomb()
    {
        fxbomb.GetComponent<ParticleSystem>().Play();
        fxbomb.GetComponent<Collider>().enabled = true;
    }

    public void oFFfxbomb()
    {
        fxbomb.GetComponent <ParticleSystem>().Stop();
        fxbomb.GetComponent<Collider>().enabled = false;
    }public void ONfxulti()
    {
        fxulti.GetComponent<ParticleSystem>().Play();
        fxulti.GetComponent<Collider>().enabled = true;
    }

    public void oFFfxulti()
    {
        fxulti.GetComponent <ParticleSystem>().Stop();
        fxulti.GetComponent<Collider>().enabled = false;
    }public void ONfxultibomb()
    {
        fxultibomb.GetComponent<ParticleSystem>().Play();
        fxultibomb.GetComponent<Collider>().enabled = true;
    }

    public void oFFfxultibomb()
    {
        fxultibomb.GetComponent <ParticleSystem>().Stop();
        fxultibomb.GetComponent<Collider>().enabled = false;
    }public void ONfxulti2()
    {
        fxulti2.GetComponent<ParticleSystem>().Play();
        fxulti2.GetComponent<Collider>().enabled = true;
    }

    public void oFFfxulti2()
    {
        fxulti2.GetComponent <ParticleSystem>().Stop();
        fxulti2.GetComponent<Collider>().enabled = false;
    }


}
