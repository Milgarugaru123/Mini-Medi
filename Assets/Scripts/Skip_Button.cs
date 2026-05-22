using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections;

public class Skip_Button : MonoBehaviour
{
    private float timer = 0f;
    public GameObject target;
    public Camera target_cam;
    private float target_z_abs;
    private SpriteRenderer button_renderer;
    private Sprite button_on;
    private Sprite button_blink = null;
    private bool is_paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target_z_abs = target.transform.position.z - target_cam.transform.position.z;
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
        GameObject.Find("Story Controller").SendMessage("PauseTimer");
        target.transform.position = target_cam.transform.position + (Vector3.forward * target_z_abs);
        target.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1f)
        {
            button_renderer.sprite = button_blink;
            if (timer >= 1.5f)
            {
                button_renderer.sprite = button_on;
                timer = 0f;
            }
        }
        if (!is_paused) timer += Time.deltaTime;
    }
}
