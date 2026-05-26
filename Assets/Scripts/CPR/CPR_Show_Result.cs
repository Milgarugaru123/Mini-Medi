using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CPR_Show_Result : MonoBehaviour
{
    public TMP_Text score;
    private int score_value;
    private int padding_len;
    private string padding;
    public GameObject sfx_group;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_value = (int)Data_Controller.minigame_score;
        padding_len = score_value.ToString().Length;
        padding = "";
        for (int i = 0; i < (6 - padding_len); i++) padding += "0";
        score.text = (padding + score_value.ToString());
        StartCoroutine("SfxStart", score_value);
    }

    private IEnumerator SfxStart(int value)
    {
        yield return new WaitForSeconds(2.5f);
        if (value > 80000) sfx_group.transform.GetChild(0).GetComponent<AudioSource>().Play();
        else if (value <= 80000 && value > 50000) sfx_group.transform.GetChild(1).GetComponent<AudioSource>().Play();
        else sfx_group.transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
