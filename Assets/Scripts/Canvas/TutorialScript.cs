using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private bool isFirst;

    [SerializeField]
    private GameObject TutorialCanvas;

    [SerializeField]
    private GameObject[] TutorialPage;

    [SerializeField]
    private GameObject[] PageDot;

    [SerializeField]
    private GameObject[] SubCombat;

    private int current, previous, subCombatCurrent, subCombatPrevious, currentStep, prevStep, currentUtil, prevUtil;

    public GameObject[] utility;

    public GameObject[] punch;
    public GameObject[] kick;
    public GameObject[] sp_punch;
    public GameObject[] sp_kick;
    public GameObject[] ultimate;
    public GameObject[] dash;


    private void Awake()
    {
        Time.timeScale = 0;
        current = 0;
        previous = 0;
        subCombatCurrent = 0;
        subCombatPrevious = 0;
        currentStep = 0;
        prevStep = 0;

        if (isFirst)
        {
            TutorialCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        Debug.Log("current : " + current);

        Debug.Log("previous : " + previous);
    }
    // Start is called before the first frame update
    void Start()
    {
        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void PreviousPage()
    {
        TutorialPage[current].SetActive(false);
        PageDot[current].SetActive(false);
        
        if(current >= 0)
        {
            previous--;

            if(previous == -1)
            {
                previous = TutorialPage.Length - 1;
            }

        }

        current = previous;

        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void NextPage()
    {
        TutorialPage[current].SetActive(false);
        PageDot[current].SetActive(false);

        if(current <= TutorialPage.Length)
        {
            current++;

            if(current == TutorialPage.Length)
            {
                current = 0;
            }
        }

        previous = current;
        TutorialPage[current].SetActive(true);
        PageDot[current].SetActive(true);
    }

    public void NextUtil()
    {
        utility[currentUtil].SetActive(false);

        if (currentUtil <= utility.Length)
        {
            currentUtil++;

            if (currentUtil == utility.Length)
            {
                currentUtil = 0;
            }
        }

        prevUtil = currentUtil;
        utility[currentUtil].SetActive(true);
    }

    public void PrevUtil()
    {
        utility[currentUtil].SetActive(false);

        if (prevUtil >= 0)
        {
            prevUtil--;

            if (prevUtil == -1)
            {
                prevUtil = utility.Length - 1;
            }
        }

        currentUtil = prevUtil;
        utility[currentUtil].SetActive(true);
    }

    public void NextCombat()
    {
        SubCombat[subCombatCurrent].SetActive(false);
        subCombatPrevious = subCombatCurrent;

        if(subCombatCurrent <= SubCombat.Length)
        {
            subCombatCurrent++;

            if(subCombatCurrent == SubCombat.Length)
            {
                subCombatCurrent = 0;
            }
        }

        SubCombat[subCombatCurrent].SetActive(true);
    }

    public void PreviousCombat()
    {
        SubCombat[subCombatCurrent].SetActive(false);
        
        if(subCombatPrevious >= 0)
        {
            subCombatPrevious--;

            if(subCombatPrevious == -1)
            {
                subCombatPrevious = SubCombat.Length - 1;
            }
        }

        subCombatCurrent = subCombatPrevious;

        SubCombat[subCombatCurrent].SetActive(true);
    }

    public void NextStep()
    {
        GameObject[] Combat;

        if (subCombatCurrent == 0)
        {
            Combat = punch;
        }
        else if (subCombatCurrent == 1)
        {
            Combat = kick;
        }
        else if (subCombatCurrent == 2)
        {
            Combat = sp_punch;
        }
        else if (subCombatCurrent == 3)
        {
            Combat = sp_kick;
        }
        else if (subCombatCurrent == 4)
        {
            Combat = ultimate;
        }
        else
        {
            Combat = dash;
        }


        Combat[currentStep].SetActive(false);
        prevStep = currentStep;

        if (currentStep <= Combat.Length)
        {
            currentStep++;

            if (currentStep == Combat.Length)
            {
                currentStep = 0;
            }
        }
        Combat[currentStep].SetActive(true);
    }

    public void PreviousStep()
    {
        GameObject[] Combat;

        if (subCombatCurrent == 0)
        {
            Combat = punch;
        }
        else if (subCombatCurrent == 1)
        {
            Combat = kick;
        }
        else
        {
            Combat = sp_punch;
        }

        Combat[currentStep].SetActive(false);

        if (prevStep >= 0)
        {
            prevStep--;

            if (prevStep == -1)
            {
                prevStep = Combat.Length - 1;
            }
        }

        currentStep = prevStep;
        Combat[currentStep].SetActive(true);
    }

    public void closeTutorial()
    {
        TutorialCanvas.SetActive(false);
        isFirst = !isFirst;
        Time.timeScale = 1;
    }

}
