using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtonClick : MonoBehaviour
{
    public Button btnCreateBuilding;
    private GameObject prefab;
    public Transform spawnPosition;
    public float followSpeed = 10;
    private GameObject Building;
    // Start is called before the first frame update
    private void Awake()
    {
        var path = "Prefabs/BuildingTest";
        this.prefab = Resources.Load<GameObject>(path);
    }
    void Start()
    {
        this.btnCreateBuilding.onClick.AddListener(OnClickBtnCreateBuilding);
    }
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
            //float mouseZ = Input.GetAxis("Mouse Z");
            spawnPosition.Translate(Vector3.left * followSpeed * Time.smoothDeltaTime * mouseX, Space.World);
            spawnPosition.Translate(Vector3.forward * followSpeed * Time.smoothDeltaTime * mouseY, Space.World);
            Building.transform.localPosition = spawnPosition.position;
            Debug.Log("test");
        }
    }
    private void OnClickBtnCreateBuilding()
    {
        //Shell
        var shell = this.CreateShell();
        //Model
        Building = this.CreateModel();
        //Info
        Building.transform.SetParent(shell.transform, false);
        //model.transform.localPosition = Vector3.zero;
        Building.transform.localPosition = spawnPosition.position;
    }

    private GameObject CreateShell()
    {
        return new GameObject("Building");
    }

    private GameObject CreateModel()
    {
        return Instantiate<GameObject>(this.prefab);
    }
    //public void OnClickBdgBtn1()
    //{

    //}
}
