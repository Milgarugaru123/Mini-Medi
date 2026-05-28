using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CPR_Minigame_Normal : MonoBehaviour
{
    private float timer = -0.19f;    //시작 offset
    private float note_timer = 0f;
    private bool is_started = false;
    private bool is_paused = true;
    public AudioSource bgm;
    public GameObject sfx_group;
    public TMP_Text score;
    public Text call_message;
    public Text call_message_large;
    private int message_large_limit = 45;
    private bool is_pressed = true;
    private float timer_max = 0.5f;
    private float timer_mid;
    private float perfect_timing = 0.04f;   //8
    private float great_timing = 0.075f;    //15 (7)
    private float good_timing = 0.1f;       //20 (5)
    private int score_value = 0;
    private int score_value_prev = 0;       //이론상 최대 점수: 400 * 10 * 25 = 100000점
    private int score_mul = 25;
    private int score_padding_len = 0;
    private string padding;
    private int note_count = 0;            //총 클릭 횟수: 400회 기준
    public string next_scene;
    private bool is_space_down = false;
    public GameObject arm;
    private float common_medi_info_dist = 0.4f;
    public GameObject judgement;
    public GameObject metronome;
    private Transform metronome_niddle;
    private float wave_range = 60f;
    private float left_right_sign = 1f;     //오른쪽부터
    public TMP_Text debug_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        metronome.SetActive(false);
        metronome_niddle = metronome.transform.GetChild(0).transform;
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        bgm.Pause();
        timer_mid = timer_max / 2f;
        //Debug.Log(Data_Controller.medi_info.CPR_info[0]);
    }

    private IEnumerator ReadyCountdown()
    {
        bgm.UnPause();
        yield return new WaitForSeconds(0.46f);
        bgm.Pause();
        yield return new WaitForSeconds(4.5f);
        /*call_message.text = "";
        call_message_large.text = "";
        yield return new WaitForSeconds(1f);
        call_message_large.DOText("Are you ready?", 0.5f);
        sfx_group.transform.GetChild(1).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.2f);
        call_message_large.text = "3";
        sfx_group.transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "2";
        sfx_group.transform.GetChild(3).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "1";
        sfx_group.transform.GetChild(4).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "GO!";*/
        StartCoroutine("ResumeCountdown");
        yield return new WaitForSeconds(3.7f);
        sfx_group.transform.GetChild(5).GetComponent<AudioSource>().Play();
        yield break;
    }

    private IEnumerator ResumeCountdown()
    {
        call_message.text = "";
        call_message_large.text = "";
        yield return new WaitForSeconds(1f);
        call_message_large.DOText("Are you ready?", 0.5f);
        sfx_group.transform.GetChild(1).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.2f);
        call_message_large.text = "3";
        sfx_group.transform.GetChild(2).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "2";
        sfx_group.transform.GetChild(3).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "1";
        sfx_group.transform.GetChild(4).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        call_message_large.text = "GO!";
        bgm.UnPause();
        is_paused = false;
        yield break;
    }

    public void MinigameContinue()
    {
        if (is_started)
        {
            metronome.SetActive(true);
            StartCoroutine("ResumeCountdown");
        }
    }

    public void MinigamePause()
    {
        if (is_started)
        {
            is_paused = true;
            metronome.SetActive(false);
            StopCoroutine("ReadyCountdown");
            StopCoroutine("ResumeCountdown");
            bgm.Pause();
        }
    }

    public void ScoreCheck()
    {
        if (is_space_down)
        {
            is_space_down = false;
            return;
        }
        else
        {
            if (is_paused) return;
            if (!is_pressed)
            {
                is_space_down = true;
                debug_text.text = timer.ToString();     //디버깅용
                Debug.Log("pressed: " + timer);
                is_pressed = true;
                if (timer >= (timer_max - perfect_timing) && timer <= (timer_max + perfect_timing))
                {
                    //Debug.Log("perfect");
                    score_value += score_mul * 10;
                    judgement.SendMessage("Judgement", 0, SendMessageOptions.DontRequireReceiver);
                }
                else if (timer >= (timer_max - great_timing) && timer <= (timer_max + great_timing))
                {
                    //Debug.Log("great");
                    score_value += score_mul * 5;
                    judgement.SendMessage("Judgement", 1, SendMessageOptions.DontRequireReceiver);
                }
                else if (timer >= (timer_max - good_timing) && timer <= (timer_max + good_timing))
                {
                    //Debug.Log("good");
                    score_value += score_mul * 2;
                    judgement.SendMessage("Judgement", 2, SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    //Debug.Log("missed");
                    judgement.SendMessage("Judgement", 3, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    public void StartMinigame()
    {
        is_started = true;
        metronome.SetActive(true);
        StartCoroutine("ReadyCountdown");
    }
    
    private IEnumerator EndMinigame()
    {
        GameObject.Find("Menu Button").gameObject.SetActive(false);
        sfx_group.transform.GetChild(7).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        sfx_group.transform.GetChild(6).GetComponent<AudioSource>().volume = 0f;
        sfx_group.transform.GetChild(6).GetComponent<AudioSource>().Play();
        sfx_group.transform.GetChild(6).GetComponent<AudioSource>().DOFade(1f, 2f);
        yield return new WaitForSeconds(7f);
        sfx_group.transform.GetChild(7).GetComponent<AudioSource>().DOFade(0f, 2f);
        yield return new WaitForSeconds(3f);
        sfx_group.transform.GetChild(6).GetComponent<AudioSource>().DOFade(0f, 2f);
        yield return new WaitForSeconds(5f);
        Data_Controller.minigame_score = score_value;
        GameObject.Find("Fade Canvas").SendMessage("FadeOut");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Load Result");
        SceneManager.LoadScene(next_scene);
        //yield break;
    }

    private IEnumerator ScoreValueChange()
    {
        score_value_prev = score_value;
        score_padding_len = score_value.ToString().Length;
        padding = "";
        for (int i = 0; i < (6 - score_padding_len); i++) padding += "0";
        score.text = (padding + score_value.ToString());
        yield break;
    }

    private IEnumerator RandomMediInfo()
    {
        float rand = UnityEngine.Random.value;
        int rand_idx = UnityEngine.Random.Range(0, 10000);
        //Debug.Log("rand =  " + rand + ", idx = " + rand_idx);
        string temp = null;
        call_message.text = "";
        call_message_large.text = "";
        if (rand <= common_medi_info_dist)
        {
            temp = Data_Controller.medi_info.common_medi_info[rand_idx % Data_Controller.medi_info.common_medi_info.Length];
            if (temp.Length > message_large_limit) call_message.DOText(temp, 2f);
            else call_message_large.DOText(temp, 2f);
        }
        else
        {
            temp = Data_Controller.medi_info.CPR_info[rand_idx % Data_Controller.medi_info.CPR_info.Length];
            if (temp.Length > message_large_limit) call_message.DOText(temp, 2f);
            else call_message_large.DOText(temp, 2f);
        }
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        if (note_timer >= timer_max)
        {
            note_timer -= timer_max;
            if (note_count < 32) sfx_group.transform.GetChild(0).GetComponent<AudioSource>().Play();
            if (note_count % 40 == 0) StartCoroutine("RandomMediInfo");
        }
        if (timer < timer_mid)
        {
            is_pressed = true;
            metronome_niddle.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (timer >= timer_max + timer_mid)
        {
            is_pressed = false;
            Debug.Log(note_count );
            timer -= timer_max;
            //if (note_count == 240) timer += 0.05f;
            if (note_count == 385) StartCoroutine("EndMinigame");
            if (note_count >= 401)
            {
                arm.SendMessage("ArmOff", SendMessageOptions.DontRequireReceiver);
                is_paused = true;
            }
            if (left_right_sign == 1f) left_right_sign = 2f;
            else left_right_sign = 1f;
            note_count++;
        }
        else if (timer >= timer_mid)
        {
            float wave_timer = math.remap(0f, timer, 0f, 3f, timer - timer_mid);
            if (wave_timer > 1f)
            {
                wave_timer = 2f - wave_timer;
                if (wave_timer < 0f) wave_timer = 0f;
            }
            metronome_niddle.rotation = Quaternion.Euler(0, 0, (wave_timer * wave_range * Mathf.Pow(-1, left_right_sign)));
        }
        if (score_value != score_value_prev) StartCoroutine("ScoreValueChange");
        if (!is_paused)
        {
            timer += Time.deltaTime;
            note_timer += Time.deltaTime;
        }
    }
}
