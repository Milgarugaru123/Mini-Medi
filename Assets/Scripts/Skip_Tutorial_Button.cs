using UnityEngine;
using System.Collections;

public class Skip_Tutorial_Button : MonoBehaviour
{
    private float timer = 0f;
    public GameObject target;
    private SpriteRenderer button_renderer;
    private Sprite button_on;
    private Sprite button_blink = null;
    private bool is_paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_renderer = GetComponent<SpriteRenderer>();
        button_on = button_renderer.sprite;
    }

    public void ContinueBlink()
    {
        is_paused = false;
    }

    private void OnMouseDown()
    {
        is_paused = true;
        target.transform.position = (Vector3.forward * 10);
        target.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1.5f)
        {
            button_renderer.sprite = button_blink;
            if (timer >= 2f)
            {
                button_renderer.sprite = button_on;
                timer = 0f;
            }
        }
        if (!is_paused) timer += Time.deltaTime;
    }
}
