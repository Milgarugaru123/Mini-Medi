using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class Screen_Resolution_Controller : MonoBehaviour
{
    public static bool isFullscreen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isFullscreen) Screen.SetResolution(1920, 1080, false);
    }

    public void ToggleScreenResolution()
    {
        if (isFullscreen)
        {
            Screen.SetResolution(1920, 1080, false);
            isFullscreen = false;
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
            isFullscreen = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
