using UnityEngine;
using UnityEngine.UI;

public class Fullscreen_Toggle_Button : MonoBehaviour
{
    private Toggle fullscreen_toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fullscreen_toggle = GetComponent<Toggle>();
        if (Screen_Resolution_Controller.is_fullscreen_mode) fullscreen_toggle.SetIsOnWithoutNotify(true);
        else fullscreen_toggle.SetIsOnWithoutNotify(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
