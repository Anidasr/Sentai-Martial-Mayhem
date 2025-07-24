using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteranimation : MonoBehaviour
{
    private Animator anim;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_sound, fall_sound, ground_hit_sound, dead_sound,Kick_Sound,get_hit;

    void Awake()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    public void Walk(bool move)
    {
        anim.SetBool("Movement", move);
    }

    public void Run(bool lari)
    {
        anim.SetBool("Running", lari);
    }
    public void Guard(bool defend)
    {
        anim.SetBool("guard", defend);
    }

    public void Punch()
    {
        anim.SetTrigger(AnimationTags.PUNCH_TRIGGER);
    }

    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH2_TRIGGER);
    }

    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH3_TRIGGER);
    }

    public void Kick()
    {
        anim.SetTrigger(AnimationTags.KICK_TRIGGER);
    }

    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK2_TRIGGER);
    }

    public void Kick_3()
    {
        anim.SetTrigger(AnimationTags.KICK3_TRIGGER);
    }

    public void Strongpunch()
    {
        anim.SetTrigger(AnimationTags.STRONGPUNCH_TRIGGER);
    }

    public void Specialkick()
    {
        anim.SetTrigger(AnimationTags.SPECIALKICK_TRIGGER);
    }

    public void Counter()
    {
        anim.SetTrigger(AnimationTags.COUNTER);
    }

    public void wakeup()
    {
        anim.SetTrigger(AnimationTags.Wakeup);
    }

    public void Jump()
    {
        anim.SetTrigger(AnimationTags.JUMP_TRIGGER);
    }

    public void throwe()
    {
        anim.SetTrigger(AnimationTags.throwe);
    }


    public void Hit1(bool hit1)
    { anim.SetBool("gethit1", hit1);}

    public void Die()
    {
        anim.SetTrigger(AnimationTags.DIE_TRIGGER);
    }

    public void Dash()
    {
        anim.SetTrigger(AnimationTags.Dash);
    }

    public void Ulti()
    {
        anim.SetTrigger(AnimationTags.Ulti);
    }

    //---------SFX-------------
    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_sound;
        audioSource.Play();
    }

    void Strong_Punch_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = ground_hit_sound;
        audioSource.Play();
    }
    void Get_Hit_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = get_hit;
        audioSource.Play();
    }

    void Strong_Kick_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = Kick_Sound;
        audioSource.Play();
    }

    void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = dead_sound;
        audioSource.Play();
    }

    void Enemy_KnockedDown()
    {
        audioSource.clip = fall_sound;
        audioSource.Play();
    }


}
