using UnityEngine;
using System.Collections;

public class Current_Page_Follow : MonoBehaviour
{
    public Transform target;
    private Transform cam_tr;
    [SerializeField] float smoothing = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}
