using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Button_UI_Long : MonoBehaviour
{
    private GameObject Button_Long;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button_Long = GetComponent<GameObject>();
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
        Debug.Log("Mouse Clicked on Sprite");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Released on Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
