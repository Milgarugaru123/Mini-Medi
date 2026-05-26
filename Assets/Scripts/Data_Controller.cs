using System;
using UnityEngine;

[Serializable]
public class Medi_Info
{
    public string[] common_medi_info;
    public string[] CPR_info;
    public string[] Hives_info;
    public string[] FAST_info;
}

public class Data_Controller : MonoBehaviour
{
    private TextAsset json_temp;
    public static Medi_Info medi_info;
    [SerializeField] public static float minigame_score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        json_temp = Resources.Load<TextAsset>("JSON/Medi_Info");
        medi_info = new Medi_Info();
        medi_info = JsonUtility.FromJson<Medi_Info>(json_temp.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
