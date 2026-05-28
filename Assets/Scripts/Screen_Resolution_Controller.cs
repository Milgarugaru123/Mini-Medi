using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class Screen_Resolution_Controller : MonoBehaviour
{
    public static bool is_fullscreen_mode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!is_fullscreen_mode) Screen.SetResolution(1920, 1080, false);
        else Screen.SetResolution(1920, 1080, true);
    }

    public void ToggleScreenResolution()
    {
        if (is_fullscreen_mode)
        {
            Screen.SetResolution(1920, 1080, false);
            is_fullscreen_mode = false;
        }
        else
        {
            Screen.SetResolution(1920, 1080, true);
            is_fullscreen_mode = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
