using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Threading;

public class Menu_Button : MonoBehaviour
{
    public GameObject target;
    private SpriteRenderer this_renderer;
    private Sprite next_sprite = null;
    private Sprite sprite_on;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_on = this_renderer.sprite;
        target.SetActive(false);
    }

    public void MenuDown()
    {
        this_renderer.sprite = sprite_on;
    }

    public void BackToMenu()
    {
        target.transform.position = (Vector3.forward * 20);
        target.SetActive(true);
    }

    private void OnMouseDown()
    {
        this_renderer.sprite = next_sprite;
        target.transform.position = (Vector3.forward * 20);
        target.SetActive(true);
        GameObject.Find("Minigame Controller").gameObject.SendMessage("SkipButtonHide", SendMessageOptions.DontRequireReceiver);
        GameObject.Find("Minigame Controller").gameObject.SendMessage("MinigamePause", SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
