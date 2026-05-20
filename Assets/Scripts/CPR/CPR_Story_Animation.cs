using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class CPR_Story_Animation : MonoBehaviour
{
    private float timer = 0f;
    public Camera cam;
    public GameObject skip_button;
    public AudioSource bgm;
    public GameObject sfx_group;
    private AudioSource sfx;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    private GameObject[] cut_scenes = new GameObject[20];
    public string next_scene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.transform.position = Vector3.zero;
        GameObject temp_obj = null;
        int i = 0;
        while (i < 9)
        {
            temp_obj = Page1.transform.GetChild(i).gameObject;
            cut_scenes[i] = temp_obj;
            cut_scenes[i].SetActive(false);
            i++;
        }
        i = 0;
        while (i < 4)
        {
            temp_obj = Page2.transform.GetChild(i).gameObject;
            cut_scenes[i + 9] = temp_obj;
            cut_scenes[i].SetActive(false);
            i++;
        }
        i = 0;
        while (i < 7)
        {
            temp_obj = Page3.transform.GetChild(i).gameObject;
            cut_scenes[i + 13] = temp_obj;
            cut_scenes[i].SetActive(false);
            i++;
        }
    }

    IEnumerator ToMinigame()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("Fade Canvas").SendMessage("FadeOut");
        yield return new WaitForSeconds(2f);
        Debug.Log("Load Minigame");
        SceneManager.LoadScene(next_scene);
        //yield break;
    }

    public void SkipStory()
    {
        Debug.Log("Skip Story");
        skip_button.SetActive(false);
        timer = -100f;
        bgm.Stop();
        cam.transform.position = (Vector3.right * 300) + (Vector3.forward * -10);
        sfx = sfx_group.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        sfx.Play();
        StartCoroutine("ToMinigame");
    }

    public void ContinueStory()
    {
        Debug.Log("Continue Story");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 2f)
        {
            cut_scenes[0].SetActive(true);

        }
        if (timer > 4f)
        {
            cut_scenes[1].SetActive(true);
        }
        if (timer > 6f)
        {
            cut_scenes[2].SetActive(true);
        }
        if (timer > 8f)
        {
            cut_scenes[3].SetActive(true);
        }
        if (timer > 10f)
        {
            cut_scenes[4].SetActive(true);
        }
        if (timer > 12f)
        {
            cut_scenes[5].SetActive(true);
        }
        if (timer > 14f)
        {
            cut_scenes[6].SetActive(true);
        }
        if (timer > 16f)
        {
            cut_scenes[7].SetActive(true);
        }
        if (timer > 18f)
        {
            cut_scenes[8].SetActive(true);
        }
        if (timer > 20f)
        {
            cam.transform.position = (Vector3.right * 100) + (Vector3.forward * -10);
            cut_scenes[9].SetActive(true);
        }
        if (timer > 22f)
        {
            cut_scenes[10].SetActive(true);
        }
        if (timer > 24f)
        {
            cut_scenes[11].SetActive(true);
        }
        if (timer > 26f)
        {
            cut_scenes[12].SetActive(true);
        }
        if (timer > 28f)
        {
            cam.transform.position = (Vector3.right * 200) + (Vector3.forward * -10);
            cut_scenes[13].SetActive(true);
        }
        if (timer > 30f)
        {
            cut_scenes[14].SetActive(true);
        }
        if (timer > 32f)
        {
            cut_scenes[15].SetActive(true);
        }
        if (timer > 34f)
        {
            cut_scenes[16].SetActive(true);
        }
        if (timer > 36f)
        {
            cut_scenes[17].SetActive(true);
        }
        if (timer > 38f)
        {
            cut_scenes[18].SetActive(true);
        }
        if (timer > 40f)
        {
            cut_scenes[19].SetActive(true);
        }
        if (timer > 42f)
        {
            cut_scenes[20].SetActive(true);
        }

        timer += Time.deltaTime;
    }
}
