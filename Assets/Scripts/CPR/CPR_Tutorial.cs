using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPR_Tutorial : MonoBehaviour
{
    private float timer = 0f;
    public AudioSource bgm;
    public AudioSource heartbeat;
    private int message_large_limit = 45;
    private int message_num = 0;
    private int message_flag = 2;   // 0: 메세지 출력 중, 1: 메세지 출력 완료, 2: 메세지 상호작용 금지
    public GameObject skip_button;
    public Text call_message;
    public Text call_message_large;
    private Tween message_tween;
    private string[] tutorial_messages;
    private bool is_tutorial = true;
    public GameObject arm;
    private bool is_space_down = false;
    private bool is_pressed = true;
    private float timer_max = 0.5f;
    private float timer_mid;
    private float perfect_timing = 0.04f;   //8
    private float great_timing = 0.075f;    //15 (7)
    private float good_timing = 0.1f;       //20 (5)
    private bool is_paused = false;
    public GameObject judgement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DOTween.Init(false, true, default).SetCapacity(500, 30);
        //message_tween = null;
        timer_mid = timer_max / 2f;
        call_message.text = "";
        call_message_large.text = "\"CPR(심폐소생술)\"";
        tutorial_messages = new string[22] {
            "심폐소생술 미니게임 튜토리얼에 오신 것을 환영합니다!",
            "심폐소생술은 심정지 환자의 생명을 구할 수 있는 아주 중요한 응급처치법입니다.",
            "맞다, 이러고 있을 때가 아니죠!",
            "방금 전에 쓰러진 손님이 당신 앞에 누워있어요!",
            "겉보기에는 그냥 자고있는 것 같지만, 당신은 손님이 쓰러지는 장면을 목격했습니다.",
            "그렇다면, 이상이 있는지 '환자의 상태'를 확인해봐요!",
            "반응도 없고, 의식도 없는 것 같아 보이네요...",
            "높은 확률로 심정지 환자인 것 같으니 빠르게 심폐소생술을 실시해보도록 해요!",
            "방법을 잘 모르더라도 제가 순서대로 알려드릴 테니 따라해주시기만 하면 됩니다!",
            "우선 환자와 수직이 되게 환자의 옆에서 무릎을 꿇고 앉아주세요.",
            "그 다음, 가슴뼈(흉골)의 아래쪽 절반 부위에 깍지를 낀 두 손의 손바닥 뒷꿈치를 대주세요!",  //arm.active (11)
            "손가락이 가슴에 닿지 않도록 주의하면서 양 팔이 환자의 몸과 수직이 되도록 쭉 피고 가슴압박을 실시합니다.",
            "가슴압박을 할 때에는 체중을 실어서 해야 돼요. 안 그러면 생각보다 훨~~씬 힘들답니다.",
            "여기서는 조금 편하게 스페이스바(Space)를 눌러서 실시할 수 있어요!",
            "일반적으로 가슴압박은 성인 기준 분당 100~120회의 속도와 약 5cm 깊이로 강하고 빠르게 시행해야 해요.",
            "그럼 심장박동 소리에 맞춰 가슴압박을 10번만 해볼까요? 분당 120회를 기준으로 합니다!",   //heartbeat.enabled (16)
            "다시 한 번 해 볼까요? 스페이스바(Space)를 눌러서 압박하는 거에요!",    //hearbeat.enabled (17)
            "정말 잘 하셨어요!",   //heartbeat.disabled
            "원래는 인공호흡도 같이 병행하거나, 자동제세동기(심장충격기)도 같이 사용할 수 있으면 더 좋지만...",
            "지금은 급한대로 '가슴압박소생술'을 실시하도록 해요!",
            "구조대원들이 방금 출발했다고 하니, 도착할 때까지 잘 부탁드립니다!",
            "박자에 맞춰서 하실 수 있도록 음악도 준비해 봤어요~"};
        StartCoroutine("MessageDelay");
    }

    public void SkipButtonShow()
    {
        if (is_tutorial) skip_button.SetActive(true);
    }

    public void SkipButtonHide()
    {
        if (is_tutorial) skip_button.SetActive(false);
    }

private IEnumerator MessageDelay()
    {
        yield return new WaitForSeconds(0.5f);
        message_flag = 1;
        yield break;
    }

    private void TutorialEnd()
    {
        is_tutorial = false;
        StopCoroutine("HeartbeatTutorial");
        StopCoroutine("MessageDelay");
        arm.SetActive(true);
        arm.SendMessage("ArmOn", SendMessageOptions.DontRequireReceiver);
        message_tween.Kill();
        message_num = tutorial_messages.Length;
        bgm.DOFade(0f, 3f);
        call_message.text = "";
        call_message_large.text = "튜토리얼이 종료되었습니다.\nCPR 미니게임이 곧 시작됩니다.";
        skip_button.SetActive(false);
        SendMessage("StartMinigame", SendMessageOptions.DontRequireReceiver);
    }

    private IEnumerator HeartbeatTutorial()
    {
        int i = 0;
        bgm.DOFade(0.25f, 2f);
        yield return new WaitForSeconds(3f);
        while (i < 10)
        {
            yield return new WaitForSeconds(0.5f);
            heartbeat.Play();
            Debug.Log(timer);
            i++;
        }
        bgm.DOFade(1f, 2f);
        yield return new WaitForSeconds(0.5f);
        message_flag = 1;
        is_paused = true;
        is_pressed = true;
        yield return new WaitForSeconds(2.5f);
        yield break;
    }

    public void TutorialJudgementCheck()
    {
        if (is_space_down)
        {
            is_space_down = false;
            return;
        }
        else
        {
            if (!is_pressed)
            {
                Debug.Log("pressed: " + timer);
                is_pressed = true;
                if (timer >= (timer_max - perfect_timing) && timer <= (timer_max + perfect_timing))
                {
                    Debug.Log("perfect");
                    judgement.SendMessage("Judgement", 0, SendMessageOptions.DontRequireReceiver);
                }
                else if (timer >= (timer_max - great_timing) && timer <= (timer_max + great_timing))
                {
                    Debug.Log("great");
                    judgement.SendMessage("Judgement", 1, SendMessageOptions.DontRequireReceiver);
                }
                else if (timer >= (timer_max - good_timing) && timer <= (timer_max + good_timing))
                {
                    Debug.Log("good");
                    judgement.SendMessage("Judgement", 2, SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    Debug.Log("missed");
                    judgement.SendMessage("Judgement", 3, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (is_tutorial)
        {
            if (message_flag == 0)
            {
                if (message_num != 16 && message_num != 17)
                {
                    message_flag = 2;
                    message_tween.Kill();
                    call_message.text = "";
                    call_message_large.text = "";
                    if (tutorial_messages[message_num - 1].Length > message_large_limit) call_message.text = tutorial_messages[message_num - 1];
                    else call_message_large.text = tutorial_messages[message_num - 1];
                    StartCoroutine("MessageDelay");
                }
            }
            else if (message_flag == 1)
            {
                if (message_num < tutorial_messages.Length)
                {
                    message_flag = 2;
                    call_message.text = "";
                    call_message_large.text = "";
                    if (tutorial_messages[message_num].Length > message_large_limit) message_tween = call_message.DOText(tutorial_messages[message_num], 2f);
                    else message_tween = call_message_large.DOText(tutorial_messages[message_num], 2f);
                    message_num++;
                    switch (message_num)
                    {
                        case 11:
                            arm.SetActive(true);
                            arm.SendMessage("ArmOn", SendMessageOptions.DontRequireReceiver);
                            timer = 0f;
                            message_flag = 0;
                            break;

                        case 16:
                        case 17:
                            is_paused = false;
                            timer = timer_mid - 3.43f;
                            StartCoroutine("HeartbeatTutorial");
                            break;

                        default:
                            timer = 0f;
                            message_flag = 0;
                            break;
                    }
                }
                else
                {
                    message_flag = 2;
                    is_tutorial = false;
                    TutorialEnd();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_tutorial)
        {
            if (timer >= 2.5f)
            {
                StopCoroutine("MessageDelay");
                message_flag = 1;
                timer = 0f;
            }
            if (message_flag == 0) timer += Time.deltaTime;

            if (message_num == 16 || message_num == 17)
            {
                if (timer < timer_mid)
                {
                    is_pressed = true;
                }
                if (timer >= timer_max + timer_mid)
                {
                    is_pressed = false;
                    timer = timer_mid;
                }
                if (!is_paused) timer += Time.deltaTime;
            }
        }
    }
}
