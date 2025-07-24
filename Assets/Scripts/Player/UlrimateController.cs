using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UlrimateController : MonoBehaviour
{
    public static UlrimateController instance;

    [SerializeField]
    private Image[] fillUltimateBar;

    [SerializeField]
    private float chargedSpeed;
    private float charge;

    [SerializeField]
    private float maxChargeFill_1, maxChargeFill_2, maxChargeFill_3, maxChargeFill_4, maxChargeFill_5;

    private bool ultimateReady;

    private void Awake()
    {
        instance = this;

        for(int i = 0; i < 5; i++)
        {
            fillUltimateBar[i].fillAmount = 0;
        }
        ultimateReady = false;
    }

    private void Update()
    {
        charge += Time.deltaTime * chargedSpeed;

        fillUltimateBar[0].fillAmount = charge / maxChargeFill_1;
        fillUltimateBar[1].fillAmount = charge / maxChargeFill_2;
        fillUltimateBar[2].fillAmount = charge / maxChargeFill_3;
        fillUltimateBar[3].fillAmount = charge / maxChargeFill_4;
        fillUltimateBar[4].fillAmount = charge / maxChargeFill_5;

        if(fillUltimateBar[4].fillAmount == 1)
        {
            ultimateReady = true;
        }
    }

    public bool isUltimateReady()
    {
        return ultimateReady;
    }

    public void UltimateReset()
    {
        charge = 0;
        ultimateReady = false;
    }
}
