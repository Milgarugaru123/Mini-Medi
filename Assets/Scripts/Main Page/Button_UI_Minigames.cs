using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button_UI_Minigames : MonoBehaviour
{
    public string Next_Scene;
    private bool isHovering = false;
    private bool isPressed = false;
    private SpriteRenderer button_renderer;
    private Sprite button_off;
    public Sprite button_pressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_renderer = GetComponent<SpriteRenderer>();
        button_off = button_renderer.sprite;
    }

    void OnMouseEnter()
    {
        isHovering = true;
        if (isPressed)
        {
            button_renderer.sprite = button_pressed;
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
        if (isPressed)
        {
            button_renderer.sprite = button_off;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        button_renderer.sprite = button_pressed;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        button_renderer.sprite = button_off;
        if (isHovering)
        {
            SceneManager.LoadScene(Next_Scene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
