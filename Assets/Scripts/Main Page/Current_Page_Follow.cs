using UnityEngine;
using System.Collections;

public class Current_Page_Follow : MonoBehaviour
{
    public Transform target;
    private Transform cam_tr;
    private float smoothing = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, cam_tr.position.z);
        cam_tr.position = Vector3.Lerp(cam_tr.position, targetPos, smoothing);
    }
}
