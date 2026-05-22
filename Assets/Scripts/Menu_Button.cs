using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;

public class Menu_Button : MonoBehaviour
{
    public GameObject target;
    private SpriteRenderer target_renderer;
    private Sprite next_sprite = null;
    private Sprite sprite_on;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_on = target_renderer.sprite;
        target.SetActive(false);
    }

    public void MenuDown()
    {
        target_renderer.sprite = sprite_on;
    }

    public void BackToMenu()
    {
        target.transform.position = (Vector3.forward * 20);
        target.SetActive(true);
    }

    private void OnMouseDown()
    {
        target_renderer.sprite = next_sprite;
        target.transform.position = (Vector3.forward * 20);
        target.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
