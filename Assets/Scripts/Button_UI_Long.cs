using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Button_UI_Long : MonoBehaviour
{
    public string button_name;
    public GameObject target;
    private bool isHovering = false;
    private bool isPressed = false;
    private GameObject button_left;
    private GameObject button_mid;
    private GameObject button_right;
    private SpriteRenderer button_left_renderer;
    private SpriteRenderer button_mid_renderer;
    private SpriteRenderer button_right_renderer;
    private Sprite button_left_off;
    private Sprite button_mid_off;
    private Sprite button_right_off;
    public Sprite button_left_pressed;
    public Sprite button_mid_pressed;
    public Sprite button_right_pressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button_left = transform.GetChild(0).gameObject;
        button_mid = transform.GetChild(1).gameObject;
        button_right = transform.GetChild(2).gameObject;
        button_left_renderer = button_left.GetComponent<SpriteRenderer>();
        button_mid_renderer = button_mid.GetComponent<SpriteRenderer>();
        button_right_renderer = button_right.GetComponent<SpriteRenderer>();
        button_left_off = button_left_renderer.sprite;
        button_mid_off = button_mid_renderer.sprite;
        button_right_off = button_right_renderer.sprite;
    }

    private IEnumerator ToTitle()
    {
        Debug.Log("To Title");
        GameObject.Find("Fade Canvas").SendMessage("FadeOut");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main_Page");
        //yield break;
    }

    void OnMouseEnter()
    {
        isHovering = true;
        if(isPressed)
        {
            button_left_renderer.sprite = button_left_pressed;
            button_mid_renderer.sprite = button_mid_pressed;
            button_right_renderer.sprite = button_right_pressed;
        }
    }

    void OnMouseExit()
    {
        isHovering = false;
        if (isPressed)
        {
            button_left_renderer.sprite = button_left_off;
            button_mid_renderer.sprite = button_mid_off;
            button_right_renderer.sprite = button_right_off;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        button_left_renderer.sprite = button_left_pressed;
        button_mid_renderer.sprite = button_mid_pressed;
        button_right_renderer.sprite = button_right_pressed;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        button_left_renderer.sprite = button_left_off;
        button_mid_renderer.sprite = button_mid_off;
        button_right_renderer.sprite = button_right_off;
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
                target.transform.position = (Vector3.forward * 10);
            }
            if (button_name == "Credits")
            {
                target.transform.position = (Vector3.forward * 10);
            }
            if (button_name == "Back to Main")
            {
                target.transform.position = Vector3.zero;
            }
            if (button_name == "Back from Option")
            {
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * 10);
                GameObject.Find("Menu Button").SendMessage("BackToMenu", SendMessageOptions.DontRequireReceiver);
            }
            if (button_name == "Back from Credit")
            {
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * 10);
            }
            if (button_name == "Exit Game Yes")
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
            }
            if (button_name == "Exit Game No")
            {
                float target_z = target.transform.position.z;
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * target_z);
                target.SetActive(false);
            }
            if (button_name == "Skip Story Yes")
            {
                target.SetActive(false);
                float target_x = target.transform.position.x;
                float target_z = target.transform.position.z;
                target.transform.position = new Vector3(target_x, -20, target_z);
                GameObject.Find("Story Controller").SendMessage("SkipStory", SendMessageOptions.DontRequireReceiver);
            }
            if (button_name == "Skip Story No")
            {
                target.SetActive(false);
                float target_x = target.transform.position.x;
                float target_z = target.transform.position.z;
                target.transform.position = new Vector3(target_x, -20, target_z);
                GameObject.Find("Story Controller").SendMessage("ContinueTimer", SendMessageOptions.DontRequireReceiver);
                GameObject.Find("Skip Button").SendMessage("ContinueBlink", SendMessageOptions.DontRequireReceiver);
            }
            if (button_name == "Exit Minigame Yes")
            {
                StartCoroutine("ToTitle");
            }
            if (button_name == "Exit Minigame No")
            {
                float target_z = target.transform.position.z;
                target.transform.position = (Vector3.right * 40) + (Vector3.forward * target_z);
                target.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
