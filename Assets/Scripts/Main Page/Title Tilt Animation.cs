using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TitleTiltAnimation : MonoBehaviour
{
    private RectTransform title;
    private float tilt_amount = 2.5f;
    private float tilt_speed = 3f;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        title = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        title.rotation = Quaternion.Euler(0, 0, Mathf.Sin(timer) * tilt_amount);
        timer += Time.deltaTime * tilt_speed;
        if (timer > Mathf.PI * 2)
        {
            timer = 0f;
        }
    }
}
