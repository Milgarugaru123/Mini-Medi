using UnityEngine;
using System.Collections;

public class Follow_Camera : MonoBehaviour
{
    public Camera target_cam;
    private float cam_z;
    private Transform tr_self;
    public float self_z;
    private float self_z_abs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam_z = target_cam.transform.position.z;
        self_z_abs = self_z - cam_z;
        tr_self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr_self.position = target_cam.transform.position + (Vector3.forward * self_z_abs);
    }
}
