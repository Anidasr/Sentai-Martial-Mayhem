using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionController : MonoBehaviour
{
    private bool isFullscreen, isWindowed, isBorderless;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;
    [SerializeField]
    private TMP_Dropdown displayMode;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolution;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolution = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if(resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolution.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < filteredResolution.Count; i++)
        {
            string resolutionOption = filteredResolution[i].width + " x " + filteredResolution[i].height;
            options.Add(resolutionOption);
            if(filteredResolution[i].width == Screen.width && filteredResolution[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resoultionIndex)
    {
        Resolution resolution = filteredResolution[resoultionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void DisplayMode(int displayIndex)
    {
        if(displayIndex == 0)
        {
            Screen.fullScreen = true;
        }

        Screen.fullScreen = false;
    }
}
