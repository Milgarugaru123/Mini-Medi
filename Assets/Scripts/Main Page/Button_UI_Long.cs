using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class Button_UI_Long : MonoBehaviour
{
    public string button_name;
    public GameObject target;
    private bool isHovering = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMouseEnter()
    {
        isHovering = true;

    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Clicked on Sprite");
    }

    private void OnMouseUp()
    {
        if (isHovering)
        {
            if (button_name == "Game Start")
            {
                target.transform.position = (Vector3.down * 100);
            }
            if (button_name == "Ranking")
            {
                Debug.Log("TBD");
            }
            if (button_name == "Option")
            {
                target.transform.position = (Vector3.left * 0) + (Vector3.forward * 10);
            }
            if (button_name == "Credits")
            {
                target.transform.position = (Vector3.left * 0) + (Vector3.forward * 10);
            }
            if (button_name == "Back to Main")
            {
                target.transform.position = (Vector3.up * 0);
            }
            if (button_name == "Back from Option")
            {
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * 10);
            }
            if (button_name == "Back from Credit")
            {
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * 10);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
