using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System.Collections;

public class Sound_Controller : MonoBehaviour
{
    public static Sound_Controller instance { get; private set; }
    [SerializeField] [Range(0.0001f, 1f)] public float bgm = 0.75f;
    [SerializeField] [Range(0.0001f, 1f)] public float sfx = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.bgm > 1) instance.bgm = 1;
        else if (instance.bgm < 0.0001f) instance.bgm = 0.0001f;
        if (instance.sfx > 1) instance.sfx = 1;
        else if (instance.sfx < 0.0001f) instance.sfx = 0.0001f;
    }
}
