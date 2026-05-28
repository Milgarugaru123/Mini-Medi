using UnityEngine;
using UnityEngine.EventSystems;
//using DG.Tweening;
using System;
using System.Collections;

public class Arm_Movement : MonoBehaviour
{
    private SpriteRenderer arm_renderer;
    private Transform arm_tr;
    private Color original_color;
    private Color pumped_color;
    private Vector3 original_pos;
    private Vector3 pumped_pos;
    private Vector3 original_scale;
    private Vector3 pumped_scale;
    private bool is_on = false;
    private bool is_pumped = false;
    private bool is_space_down = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arm_renderer = GetComponent<SpriteRenderer>();
        arm_tr = GetComponent<Transform>();
        ColorUtility.TryParseHtmlString("#ffffffff", out original_color);
        ColorUtility.TryParseHtmlString("#c8c8c8ff", out pumped_color);
        original_pos = new Vector3(0f, -2.61f, 40f);
        pumped_pos = new Vector3(0f, -2.91f, 40f);
        original_scale = new Vector3(0.7f, 0.7f, 1f);
        pumped_scale = new Vector3(0.65f, 0.65f, 1f);
    }

    public void ArmOn()
    {
        is_on = true;
    }

    public void ArmOff()
    {
        is_on = false;
    }

    private IEnumerator Pumping()
    {
        arm_renderer.color = pumped_color;
        arm_tr.localScale = pumped_scale;
        arm_tr.position = pumped_pos;
        yield return new WaitForSeconds(0.2f);
        arm_renderer.color = original_color;
        arm_tr.localScale = original_scale;
        arm_tr.position = original_pos;
        is_pumped = false;
        yield break;
    }

    public void Pump()
    {
        if (is_space_down)
        {
            is_space_down = false;
        }
        else if (!is_pumped)
        {
            if (is_on)
            {
                is_pumped = true;
                is_space_down = true;
                StartCoroutine("Pumping");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
