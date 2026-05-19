using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Sound_Slider : MonoBehaviour
{
    private Slider sound_slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound_slider = GetComponent<Slider>();
        if (sound_slider.name == "Bgm Slider")
        {
            sound_slider.SetValueWithoutNotify(Sound_Controller.instance.bgm);
        }

        if (sound_slider.name == "Sfx Slider")
        {
            sound_slider.SetValueWithoutNotify(Sound_Controller.instance.sfx);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sound_slider.name == "Bgm Slider")
        {
            Sound_Controller.instance.bgm = sound_slider.value;
        }
        if (sound_slider.name == "Sfx Slider")
        {
            Sound_Controller.instance.sfx = sound_slider.value;
        }
    }
}
