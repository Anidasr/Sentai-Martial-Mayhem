using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ComboState
{
    None,
    Punch,
    Punch_2,
    Punch_3,
    Kick,
    Kick_2,
    Kick_3,
    StrongPunch,
    SpecialKick
}

public class PlayerAttack : MonoBehaviour
{
    private Characteranimation player_anim;
    private bool activateTimerToReset;
    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;
    private ComboState current_Combo_State;
    private bool canMove = true;

    public LayerMask collisionLayer;
    public float radius = 0.1f;

    private AttackUniversal playerAttackUniversal;
    public DValue DamageValue;                      //Call Class DValue Name

    //Cooldown Special Skill
    [SerializeField] 
    Cooldown cooldown;

    //Countdown Kick
    [SerializeField]
    private GameObject cooldown_layer;

    [SerializeField]
    private Transform skill_posisiton;

    //punch
    [SerializeField] Cooldown cooldown_punch;

    [SerializeField]
    private GameObject cooldown_layer_punch;

    [SerializeField]
    private Transform skill_posisiton_punch;



    void Awake()
    {
        player_anim = GetComponentInChildren<Characteranimation>();

        // Cek apakah ini Player1 atau Player2
        if (gameObject.CompareTag("Player"))
        {
            playerAttackUniversal = GameObject.FindGameObjectWithTag("Player").GetComponent<AttackUniversal>();
        }
        else if (gameObject.CompareTag("Player2"))
        {
            playerAttackUniversal = GameObject.FindGameObjectWithTag("Player2").GetComponent<AttackUniversal>();
        }
        else
        {
            Debug.LogError("GameObject tidak memiliki tag Player atau Player2!");
        }
    }

    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.None;
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
        specialattackpunch();
        specialattackkick();
        UltimateMove();
        Counter();
    }

    void ComboAttacks()
    {
        if ((Input.GetKeyDown(KeyCode.J) && Input.GetKey(KeyCode.LeftShift)) || Input.GetButton("XboxStrongPunch"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State != ComboState.StrongPunch)
                    {
                        current_Combo_State = ComboState.StrongPunch;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch(); // Implementasi StrongPunch sesuai kebutuhan Anda
                        playerAttackUniversal.SetDamage(DamageValue.StrongPunch1Value); //EDIT AJA YAKK ^^
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetButton("XboxPunch"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State == ComboState.Punch_3 || current_Combo_State == ComboState.Kick_3)
                    {
                        ResetComboState();
                    }
                    else if (current_Combo_State == ComboState.Punch_2)
                    {
                        current_Combo_State = ComboState.Punch_3;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch_3();
                        playerAttackUniversal.SetDamage(DamageValue.punch3Value); //EDIT AJA YAKK ^^
                    }
                    else if (current_Combo_State == ComboState.Punch)
                    {
                        current_Combo_State = ComboState.Punch_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch_2();
                        playerAttackUniversal.SetDamage(DamageValue.punch2Value); //EDIT AJA YAKK ^^
                    }
                    else
                    {
                        current_Combo_State = ComboState.Punch;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Punch();
                        playerAttackUniversal.SetDamage(DamageValue.punch1Value); //EDIT AJA YAKK ^^
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) || Input.GetButton("XboxKick"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, collisionLayer);

            foreach (Collider col in hitColliders)
            {
                if (col.CompareTag("ground"))
                {
                    if (current_Combo_State == ComboState.Punch_3 || current_Combo_State == ComboState.Kick_3)
                    {
                        ResetComboState();
                    }
                    else if (current_Combo_State == ComboState.Kick_2)
                    {
                        current_Combo_State = ComboState.Kick_3;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick_3();
                        playerAttackUniversal.SetDamage(DamageValue.kick3Value);  //EDIT AJA YAKK ^^
                    }
                    else if (current_Combo_State == ComboState.Kick)
                    {
                        current_Combo_State = ComboState.Kick_2;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick_2();
                        playerAttackUniversal.SetDamage(DamageValue.kick2Value);  //EDIT AJA YAKK ^^
                    }
                    else
                    {
                        current_Combo_State = ComboState.Kick;
                        activateTimerToReset = true;
                        current_Combo_Timer = default_Combo_Timer;
                        player_anim.Kick();
                        playerAttackUniversal.SetDamage(DamageValue.kick1Value); //EDIT AJA YAKK ^^
                    }
                }
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.None;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }

    void specialattackpunch()
    {
        if (cooldown.isCoolingDown) return;

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(cooldown_layer_punch, skill_posisiton_punch);
            player_anim.Strongpunch();
            playerAttackUniversal.SetDamage(DamageValue.SpPunchValue); //EDIT AJA YAKK ^^
            cooldown.StartCooldown();
        }
    }


    void specialattackkick()
    {
        if (cooldown_punch.isCoolingDown) return;

        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(cooldown_layer, skill_posisiton);
            player_anim.Specialkick();
            playerAttackUniversal.SetDamage(DamageValue.SpKickValue); //EDIT AJA YAKK ^^   
            cooldown_punch.StartCooldown();
        }
        
    }

    void UltimateMove()
    {
        if (!UlrimateController.instance.isUltimateReady()) return;

        if (Input.GetKeyDown(KeyCode.H))
        {
            player_anim.Ulti();
            playerAttackUniversal.SetDamage(DamageValue.ultimate); //EDIT AJA YAKK ^^ 
            UlrimateController.instance.UltimateReset();
            GetComponentInChildren<Characteranimation>().Hit1(false);
        }
    }

    public void lanjut()
    {
        canMove = true;

    }

    public void berhenti()
    {
        canMove = false;

    }

    public void Counter()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player_anim.Counter();
                playerAttackUniversal.SetDamage(DamageValue.ParryValue); 
            }
        }
    }


    [System.Serializable]               //different damage value for each attack type 
    public class DValue
    {
        public int StrongPunch1Value;   //Strong Punch attack value 
        public int punch1Value;         //Punch attack value 
        public int punch2Value;
        public int punch3Value;
        public int kick1Value;          //Kick attack value
        public int kick2Value;
        public int kick3Value;
        public int SpPunchValue;        //Special Attack value
        public int SpKickValue;
        public int ParryValue;
        public int ultimate;
    }
}
