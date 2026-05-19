using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System.Collections;

public class Sound_Value_Change : MonoBehaviour
{
    public char audio_type; // 'b' for bgm, 's' for sfx
    private float sound_value;
    private AudioSource sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (audio_type == 'b') sound_value = Sound_Controller.instance.bgm;
        else if (audio_type == 's') sound_value = Sound_Controller.instance.sfx;
        sound.outputAudioMixerGroup.audioMixer.SetFloat("Volume", Mathf.Log10(sound_value) * 20);
    }
}
