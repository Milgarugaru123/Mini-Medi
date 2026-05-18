using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class Button_UI_Minigames : MonoBehaviour
{

    private GameObject Minigame_Button;
    public string Next_Scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Hovering over Sprite");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Left Sprite");
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse clicked on Sprite");
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene(Next_Scene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
