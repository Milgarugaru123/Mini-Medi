using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Button_UI_Menu : MonoBehaviour
{
    public string button_name;
    public GameObject target;
    private GameObject menu_bg;
    private bool isHovering = false;
    private bool isPressed = false;
    private GameObject button_left;
    private GameObject button_mid;
    private GameObject button_right;
    private SpriteRenderer button_left_renderer;
    private SpriteRenderer button_mid_renderer;
    private SpriteRenderer button_right_renderer;
    private Sprite button_left_off;
    private Sprite button_mid_off;
    private Sprite button_right_off;
    public Sprite button_left_pressed;
    public Sprite button_mid_pressed;
    public Sprite button_right_pressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu_bg = GameObject.Find("Menu Background");
        button_left = transform.GetChild(0).gameObject;
        button_mid = transform.GetChild(1).gameObject;
        button_right = transform.GetChild(2).gameObject;
        button_left_renderer = button_left.GetComponent<SpriteRenderer>();
        button_mid_renderer = button_mid.GetComponent<SpriteRenderer>();
        button_right_renderer = button_right.GetComponent<SpriteRenderer>();
        button_left_off = button_left_renderer.sprite;
        button_mid_off = button_mid_renderer.sprite;
        button_right_off = button_right_renderer.sprite;
    }

    void OnMouseEnter()
    {
        isHovering = true;
        if (isPressed)
        {
            button_left_renderer.sprite = button_left_pressed;
            button_mid_renderer.sprite = button_mid_pressed;
            button_right_renderer.sprite = button_right_pressed;
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
        if (isPressed)
        {
            button_left_renderer.sprite = button_left_off;
            button_mid_renderer.sprite = button_mid_off;
            button_right_renderer.sprite = button_right_off;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        button_left_renderer.sprite = button_left_pressed;
        button_mid_renderer.sprite = button_mid_pressed;
        button_right_renderer.sprite = button_right_pressed;
    }
    private void OnMouseUp()
    {
        isPressed = false;
        button_left_renderer.sprite = button_left_off;
        button_mid_renderer.sprite = button_mid_off;
        button_right_renderer.sprite = button_right_off;
        if (isHovering)
        {
            if (button_name == "Resume")
            {
                menu_bg.transform.position = (Vector3.up * 20) + (Vector3.forward * 20);
                target.SendMessage("MenuDown", SendMessageOptions.DontRequireReceiver);
                menu_bg.SetActive(false);
            }
            if (button_name == "Option")
            {
                menu_bg.transform.position = (Vector3.up * 20) + (Vector3.forward * 20);
                target.transform.position = (Vector3.forward * 10);
                menu_bg.SetActive(false);
            }
            if (button_name == "To Title")
            {
                target.transform.position = (Vector3.forward * -5);
                target.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
