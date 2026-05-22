using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Open_Hyperlinks : MonoBehaviour
{
    public string url;
    private bool is_hovering = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnMouseOver()
    {
        is_hovering = true;
    }

    public void OnMouseExit()
    {
        is_hovering = false;
    }

    public void OnMouseUp()
    {
        if (is_hovering) Application.OpenURL(url);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
