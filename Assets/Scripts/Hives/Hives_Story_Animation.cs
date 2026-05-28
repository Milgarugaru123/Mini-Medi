using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Hives_Story_Animation : MonoBehaviour
{
    private float timer = -2f;
    public Camera cam;
    public GameObject skip_button;
    private bool skip_button_active = false;
    public AudioSource bgm;
    public GameObject sfx_group;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    private GameObject[] cut_scenes = new GameObject[20];
    private bool[] cut_scene_flags = new bool[20];
    public string next_scene;
    private bool is_paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skip_button.SetActive(false);
        cam.transform.position = Vector3.zero;
        GameObject temp_obj = null;
        int i = 0;
        while (i < 0)
        {
            temp_obj = Page1.transform.GetChild(i).gameObject;
            cut_scenes[i] = temp_obj;
            cut_scenes[i].SetActive(false);
            i++;
        }
        i = 0;
        while (i < 0)
        {
            temp_obj = Page2.transform.GetChild(i).gameObject;
            cut_scenes[i + 9] = temp_obj;
            cut_scenes[i + 9].SetActive(false);
            i++;
        }
        i = 0;
        while (i < 0)
        {
            temp_obj = Page3.transform.GetChild(i).gameObject;
            cut_scenes[i + 13] = temp_obj;
            cut_scenes[i + 13].SetActive(false);
            i++;
        }
        for (i = 0; i < 0; i++) cut_scene_flags[i] = true;
    }

    private IEnumerator ToMinigame()
    {
        Debug.Log("Story Ended");
        yield return new WaitForSeconds(5f);
        GameObject.Find("Fade Canvas").SendMessage("FadeOut");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Load Minigame");
        SceneManager.LoadScene(next_scene);
        //yield break;
    }

    public void SkipStory()
    {
        Debug.Log("Skip Story");
        is_paused = true;
        skip_button.SetActive(false);
        bgm.Stop();
        cam.transform.position = (Vector3.right * 300) + (Vector3.forward * -10);
        sfx_group.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine("ToMinigame");
    }

    public void PauseTimer()
    {
        is_paused = true;
    }

    public void ContinueTimer()
    {
        is_paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!skip_button_active && (timer >= 0f))
        {
            skip_button.SetActive(true);
            skip_button_active = true;
        }
        /*if (cut_scene_flags[0] && timer > 2f)
        {
            cut_scenes[0].SetActive(true);
            cut_scene_flags[0] = false;
            sfx_group.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[1] && timer > 3f)
        {
            cut_scenes[1].SetActive(true);
            cut_scene_flags[1] = false;
        }
        if (cut_scene_flags[2] && timer > 6f)
        {
            cut_scenes[2].SetActive(true);
            cut_scene_flags[2] = false;
            sfx_group.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[3] && timer > 11f)
        {
            cut_scenes[3].SetActive(true);
            cut_scene_flags[3] = false;
            sfx_group.transform.GetChild(3).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[4] && timer > 12.5f)
        {
            cut_scenes[4].SetActive(true);
            cut_scene_flags[4] = false;
        }
        if (cut_scene_flags[5] && timer > 14f)
        {
            cut_scenes[5].SetActive(true);
            cut_scene_flags[5] = false;
            StartCoroutine("Beeping");
        }
        if (cut_scene_flags[6] && timer > 18f)
        {
            cut_scenes[6].SetActive(true);
            cut_scene_flags[6] = false;
        }
        if (cut_scene_flags[7] && timer > 20.5f)
        {
            cut_scenes[7].SetActive(true);
            cut_scene_flags[7] = false;
            sfx_group.transform.GetChild(5).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[8] && timer > 23f)
        {
            cut_scenes[8].SetActive(true);
            cut_scene_flags[8] = false;
        }
        if (cut_scene_flags[9] && timer > 28f)
        {
            cam.transform.position = (Vector3.right * 100) + (Vector3.forward * -10);
            cut_scenes[9].SetActive(true);
            cut_scene_flags[9] = false;
            sfx_group.transform.GetChild(6).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[10] && timer > 30.5f)
        {
            cut_scenes[10].SetActive(true);
            cut_scene_flags[10] = false;
        }
        if (cut_scene_flags[11] && timer > 31.5f)
        {
            cut_scenes[11].SetActive(true);
            cut_scene_flags[11] = false;
            sfx_group.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            bgm.DOFade(0f, 5.5f);
        }
        if (cut_scene_flags[12] && timer > 34.5f)
        {
            cut_scenes[12].SetActive(true);
            cut_scene_flags[12] = false;
            sfx_group.transform.GetChild(8).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[13] && timer > 40f)
        {
            cam.transform.position = (Vector3.right * 200) + (Vector3.forward * -10);
            cut_scenes[13].SetActive(true);
            cut_scene_flags[13] = false;
            sfx_group.transform.GetChild(9).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[14] && timer > 41.5f)
        {
            cut_scenes[14].SetActive(true);
            cut_scene_flags[14] = false;
        }
        if (cut_scene_flags[15] && timer > 42.5f)
        {
            cut_scenes[15].SetActive(true);
            cut_scene_flags[15] = false;
            StartCoroutine("WindBlowing");
        }
        if (cut_scene_flags[16] && timer > 49f)
        {
            cut_scenes[16].SetActive(true);
            cut_scene_flags[16] = false;
            StartCoroutine("Call119");
        }
        if (cut_scene_flags[17] && timer > 51f)
        {
            cut_scenes[17].SetActive(true);
            cut_scene_flags[17] = false;
            StartCoroutine("CallReceived");
        }
        if (cut_scene_flags[18] && timer > 59f)
        {
            cut_scenes[18].SetActive(true);
            cut_scene_flags[18] = false;
            sfx_group.transform.GetChild(16).gameObject.GetComponent<AudioSource>().Play();
        }
        if (cut_scene_flags[19] && timer > 64f)
        {
            cut_scenes[19].SetActive(true);
            cut_scene_flags[19] = false;
            is_paused = true;
            skip_button.SetActive(false);
            sfx_group.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine("ToMinigame");
        }*/
        if (!is_paused) timer += Time.deltaTime;
    }
}
