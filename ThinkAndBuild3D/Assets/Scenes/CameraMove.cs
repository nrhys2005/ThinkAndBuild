using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera mainCamera;
    public float followSpeed = 10;
    public float zoomSpeed = 10.0f;
    
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
    void Update()
    {
        moveObject();
        Zoom();
        
    }
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }
    
    
    void moveObject()
    {

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Translate(Vector3.left * followSpeed * Time.smoothDeltaTime * mouseX, Space.World);
            transform.Translate(Vector3.forward * followSpeed * Time.smoothDeltaTime * mouseY, Space.World);
        }
    }
}
