using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using DG.Tweening;

public class Judgement_Effect_Func : MonoBehaviour
{
    private float timer = 0f;
    private GameObject perfect;
    private GameObject great;
    private GameObject good;
    private GameObject missed;
    private bool is_effect_on = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        perfect = transform.GetChild(0).gameObject;
        great = transform.GetChild(1).gameObject;
        good = transform.GetChild(2).gameObject;
        missed = transform.GetChild(3).gameObject;
        ResetJudgement();
    }

    private void ResetJudgement()
    {
        is_effect_on = false;
        perfect.SetActive(false);
        perfect.transform.localPosition = Vector3.zero;
        great.SetActive(false);
        great.transform.localPosition = Vector3.zero;
        good.SetActive(false);
        good.transform.localPosition = Vector3.zero;
        missed.SetActive(false);
        missed.transform.localPosition = Vector3.zero;
    }

    public void Judgement(int judge)
    {
        ResetJudgement();
        switch (judge)
        {
            case 0:
                perfect.SetActive(true);
                perfect.transform.DOLocalMoveY(0.6f, 0.25f);
                break;

            case 1:
                great.SetActive(true);
                great.transform.DOLocalMoveY(0.6f, 0.25f);
                break;

            case 2:
                good.SetActive(true);
                good.transform.DOLocalMoveY(0.6f, 0.25f);
                break;

            case 3:
                missed.SetActive(true);
                missed.transform.DOLocalMoveY(0.6f, 0.25f);
                break;

            default:
                break;
        }
        timer = 0;
        is_effect_on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_effect_on)
        {
            if (timer >= 1.5f) ResetJudgement();
            timer += Time.deltaTime;
        }
    }
}
