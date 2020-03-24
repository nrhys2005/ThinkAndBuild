using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 10;

    // Use this for initialization

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        moveObject();
    }
    void moveObject()
    {

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Translate(Vector3.left * speed * Time.smoothDeltaTime * mouseX, Space.World);
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * mouseY, Space.World);
        }
    }
}
