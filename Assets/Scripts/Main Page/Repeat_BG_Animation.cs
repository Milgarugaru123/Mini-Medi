using UnityEngine;
using System.Collections;

public class Repeat_BG_Animation : MonoBehaviour
{
    //[SerializeField] [Range(1f, 20f)] float speed = 3f;
    private float speed = 1.5f;
    [SerializeField] float pos_value;
    public Camera target_cam;
    private float cam_z;
    public float self_z;
    private float self_z_abs;
    private float new_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam_z = target_cam.transform.position.z;
        self_z_abs = self_z - cam_z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        new_pos = Mathf.Repeat(Time.time * speed, pos_value);
        transform.position = target_cam.transform.position + (Vector3.left * new_pos) + (Vector3.forward * self_z_abs);
    }
}
