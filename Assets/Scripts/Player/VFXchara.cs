using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXchara : MonoBehaviour
{
    public GameObject FXdamage;
    public GameObject FXtrail;
    public GameObject FXStrongpunch;
    public GameObject FXstrongpunch2;
    public GameObject FXSpecialkick;
    public GameObject FXGuard;
    public GameObject FXPunch1;
    public GameObject FXPunch2;
    public GameObject FXPunch3;
    public GameObject FXKick1;
    public GameObject FXKick2;
    public GameObject FXKick3;
    public GameObject FXBlood;
    public GameObject FXDash;

    //------Damage----
    public void ONDamage()
    {
        FXdamage.GetComponent<ParticleSystem>().Play();
        FXdamage.GetComponent<Collider>().enabled = true;
    }
    public void OFFDamage()
    {
        FXdamage.GetComponent<ParticleSystem>().Stop();
        FXdamage.GetComponent<Collider>().enabled = false;
    }
    //------Trail----
    public void ONTrail()
    {
        FXtrail.GetComponent<ParticleSystem>().Play();
        FXtrail.GetComponent<Collider>().enabled = true;
    }
    public void OFFTrail()
    {
        FXtrail.GetComponent<ParticleSystem>().Stop();
        FXtrail.GetComponent<Collider>().enabled = false;
    }
    //------Punch----
     public void ONStrongpunch()
    {
        FXStrongpunch.GetComponent<ParticleSystem>().Play();
        FXStrongpunch.GetComponent<Collider>().enabled = true;
    }
    public void OFFStrongpunch()
    {
        FXStrongpunch.GetComponent<ParticleSystem>().Stop();
        FXStrongpunch.GetComponent<Collider>().enabled = false;
    }
    //----strongpunch----
     public void ONStrongpunch2()
    {
        FXstrongpunch2.GetComponent<ParticleSystem>().Play();
        FXstrongpunch2.GetComponent<Collider>().enabled = true;
    }
    public void OFFStrongpunch2()
    {
        FXstrongpunch2.GetComponent<ParticleSystem>().Stop();
        FXstrongpunch2.GetComponent<Collider>().enabled = false;
    }


    //------Specialkick----
     public void ONSpecialkick()
    {
        FXSpecialkick.GetComponent<ParticleSystem>().Play();
        FXSpecialkick.GetComponent<Collider>().enabled = true;
    }
    public void OFFSpecialkick()
    {
        FXSpecialkick.GetComponent<ParticleSystem>().Stop();
        FXSpecialkick.GetComponent<Collider>().enabled = false;
    }
    //------punch1----
     public void ONpunch1()
    {
        FXPunch1.GetComponent<ParticleSystem>().Play();
        FXPunch1.GetComponent<Collider>().enabled = true;
    }
    public void OFFpunch1()
    {
        FXPunch1.GetComponent<ParticleSystem>().Stop();
        FXPunch1.GetComponent<Collider>().enabled = false;
    }//------punch2----
     public void ONPunch2()
    {
        FXPunch2.GetComponent<ParticleSystem>().Play();
        FXPunch2.GetComponent<Collider>().enabled = true;
    }
    public void OFFPunch2()
    {
        FXPunch2.GetComponent<ParticleSystem>().Stop();
        FXPunch2.GetComponent<Collider>().enabled = false;
    }//------punch3----
     public void ONpunch3()
    {
        FXPunch3.GetComponent<ParticleSystem>().Play();
        FXPunch3.GetComponent<Collider>().enabled = true;
    }
    public void OFFpunch3()
    {
        FXPunch3.GetComponent<ParticleSystem>().Stop();
        FXPunch3.GetComponent<Collider>().enabled = false;
    }//------kick1----
     public void ONkick1()
    {
        FXKick1.GetComponent<ParticleSystem>().Play();
        FXKick1.GetComponent<Collider>().enabled = true;
    }
    public void OFFkick1()
    {
        FXKick1.GetComponent<ParticleSystem>().Stop();
        FXKick1.GetComponent<Collider>().enabled = false;
    }//------kick2----
     public void ONkick2()
    {
        FXKick2.GetComponent<ParticleSystem>().Play();
        FXKick2.GetComponent<Collider>().enabled = true;
    }
    public void OFFkick2()
    {
        FXKick2.GetComponent<ParticleSystem>().Stop();
        FXKick2.GetComponent<Collider>().enabled = false;
    }//------kick3----
     public void ONkick3()
    {
        FXKick3.GetComponent<ParticleSystem>().Play();
        FXKick3.GetComponent<Collider>().enabled = true;
    }
    public void OFFkick3()
    {
        FXKick3.GetComponent<ParticleSystem>().Stop();
        FXKick3.GetComponent<Collider>().enabled = false;
    }//------Guard----
     public void ONGuard()
    {
        FXGuard.GetComponent<ParticleSystem>().Play();
        FXGuard.GetComponent<Collider>().enabled = true;
    }
    public void OFFGuard()
    {
        FXGuard.GetComponent<ParticleSystem>().Stop();
        FXGuard.GetComponent<Collider>().enabled = false;
    }//------Blood----
     public void ONBlood()
    {
        FXBlood.GetComponent<ParticleSystem>().Play();
        FXBlood.GetComponent<Collider>().enabled = true;
    }
    public void OFBlood()
    {
        FXBlood.GetComponent<ParticleSystem>().Stop();
        FXBlood.GetComponent<Collider>().enabled = false;
    }//------dash----
     public void ONdash()
    {
        FXDash.GetComponent<ParticleSystem>().Play();
        FXDash.GetComponent<Collider>().enabled = true;
    }
    public void OFdash()
    {
        FXDash.GetComponent<ParticleSystem>().Stop();
        FXDash.GetComponent<Collider>().enabled = false;
    }

}
