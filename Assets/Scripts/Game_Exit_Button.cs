using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game_Exit_Button : MonoBehaviour
{
    public GameObject target;
    public Camera target_cam;
    private bool isHovering = false;
    private bool isPressed = false;
    private Image button_left;
    private Image button_mid;
    private Image button_right;
    private Sprite button_left_off;
    private Sprite button_mid_off;
    private Sprite button_right_off;
    public Sprite button_left_pressed;
    public Sprite button_mid_pressed;
    public Sprite button_right_pressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_left = transform.GetChild(0).GetComponent<Image>();
        button_mid = transform.GetChild(1).GetComponent<Image>();
        button_right = transform.GetChild(2).GetComponent<Image>();
        button_left_off = button_left.sprite;
        button_mid_off = button_mid.sprite;
        button_right_off = button_right.sprite;
    }
    void OnMouseEnter()
    {
        isHovering = true;
        if (isPressed)
        {
            button_left.sprite = button_left_pressed;
            button_mid.sprite = button_mid_pressed;
            button_right.sprite = button_right_pressed;
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
        if (isPressed)
        {
            button_left.sprite = button_left_off;
            button_mid.sprite = button_mid_off;
            button_right.sprite = button_right_off;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        button_left.sprite = button_left_pressed;
        button_mid.sprite = button_mid_pressed;
        button_right.sprite = button_right_pressed;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        button_left.sprite = button_left_off;
        button_mid.sprite = button_mid_off;
        button_right.sprite = button_right_off;
        if (isHovering)
        {
            float cam_x, cam_y, target_z;
            cam_x = target_cam.transform.position.x;
            cam_y = target_cam.transform.position.y;
            target_z = target.transform.position.z;
            target.transform.position = new Vector3(cam_x, cam_y, target_z);
            target.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
