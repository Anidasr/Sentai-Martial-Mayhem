using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingScripts : MonoBehaviour
{
    public GameObject settingUI, graphicMenu, volumeMenu, controlMenu, langMenu;
    bool isOpenGraph, isOpenVolume, isOpenControll, isOpenLang;

    // Start is called before the first frame update
    void Start()
    {
        settingUI.SetActive(false);
        
    }

    public void closeSettingOnMenu()
    {
        gameObject.SetActive(false);
    }

    public void closeSetting()
    {
        settingUI.SetActive(false);
    }

    public void openGraphicSetting()
    {
        if (isOpenVolume || isOpenControll || isOpenLang)
        {
            volumeMenu.SetActive(false);
            isOpenVolume = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
            langMenu.SetActive(false);
            isOpenLang = false;
        }

        graphicMenu.SetActive(true);
        isOpenGraph = true;
    }

    public void openVolumeSetting()
    {
        if (isOpenGraph || isOpenControll || isOpenLang)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
            langMenu.SetActive(false);
            isOpenLang = false;
        }

        volumeMenu.SetActive(true);
        isOpenVolume = true;
    }

    public void openControllSetting()
    {
        if (isOpenVolume || isOpenGraph || isOpenLang)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            volumeMenu.SetActive(false);
            isOpenVolume = false;
            langMenu.SetActive(false);
            isOpenLang = false;
        }

        controlMenu.SetActive(true);
        isOpenControll = true;
    }

    public void openControllLanguange()
    {
        if (isOpenVolume || isOpenGraph || isOpenControll)
        {
            graphicMenu.SetActive(false);
            isOpenGraph = false;
            volumeMenu.SetActive(false);
            isOpenVolume = false;
            controlMenu.SetActive(false);
            isOpenControll = false;
        }

        langMenu.SetActive(true);
        isOpenLang = true;
    }


}
