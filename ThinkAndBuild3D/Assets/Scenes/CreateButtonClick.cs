using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtonClick : MonoBehaviour
{
    public Button btnCreateBuilding;
    private Camera mainCamera;
    private GameObject prefab_building;
    private Button prefab_button_check, prefab_button_cencel;
    private Button button_check, button_cencel;
    public Transform spawnPosition;
    public float followSpeed = 10;
    private GameObject Building;
    private Canvas Canvas;
    private Vector3 targetPos;
    private GameObject target;//마우스가 다운된 게임오브젝트
    CameraMove cameraMove;
    //CencelButtonClick cencelButtonClick;
    private bool buildingChoise;
    // Start is called before the first frame update
    private void Awake()
    {
        var path_building = "Prefabs/BuildingTest";
        this.prefab_building = Resources.Load<GameObject>(path_building);
        var path_button1 = "Prefabs/CheckButton";
        this.prefab_button_check = Resources.Load<Button>(path_button1);
        var path_button2 = "Prefabs/CencelButton";
        this.prefab_button_cencel = Resources.Load<Button>(path_button2);
    }
    void Start()
    {
        buildingChoise = false;
        cameraMove = FindObjectOfType<CameraMove>();

        this.btnCreateBuilding.onClick.AddListener(OnClickBtnCreateBuilding);
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    void Update()
    {
        moveObject();
    }
    void moveObject()
    {
        //해당 건물 클릭
        //cameraMove.move= false;
        if (Input.GetMouseButtonDown(0))
        {
            //내려갔다.

            //타겟을 받아온다.
            target = GetClickedObject();

            //타겟이 나인가?
            //buildingChoise = true;
            Debug.Log("Building = " + Building);
            if (true == target.Equals(Building))
            {
                //있으면 마우스 정보를 바꾼다.
                buildingChoise = true;
                cameraMove.move = false;
            }
            //else
            //{
            //    buildingChoise = false;
            //    cameraMove.move = true;
            //}
        }
        else if (Input.GetMouseButtonUp(0))
        {
            buildingChoise = false;
            cameraMove.move = true;
        }
        if ( buildingChoise)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                targetPos = hit.point;
            }
            //float mouseX = Input.GetAxis("Mouse X");
            //float mouseY = Input.GetAxis("Mouse Y");
            //float mouseZ = Input.GetAxis("Mouse Z");
            Vector2 pos = Input.mousePosition;
            pos.x -= 630;
            pos.y -= 330;
            //targetPos.y += 2;
            //pos = mainCamera.ScreenToWorldPoint(pos);
            //spawnPosition.Translate(Vector3.up *  mouseY, Space.World);
            targetPos.y = Building.transform.localPosition.y;
            Building.transform.localPosition = targetPos;
            button_cencel.transform.localPosition = pos;
            pos.x -= 60;
            button_check.transform.localPosition = pos;
            Debug.Log("x = " + pos.x);
            Debug.Log("y = " + pos.y);
            //cameraMove.move = false;
        }
    }
    private void OnClickBtnCreateBuilding()
    {
        /// 건물 생성
        //Shell
        var shell = this.CreateBuildingShell();
        shell.transform.localPosition = new Vector3(0,0,0);
        //Model
        Building = this.CreateBuildingModel();
        //Info
        Building.transform.SetParent(shell.transform, false);
        //model.transform.localPosition = Vector3.zero;
        Building.transform.localPosition = spawnPosition.position;
        Building.AddComponent<BoxCollider>();

        /// 버튼생성
        //var shell = this.CreateBtnShell();
        //Model
        button_check = this.CreateBtnModel(this.prefab_button_check);
        //Info
        button_check.transform.SetParent(Canvas.transform,false);
        //model.transform.localPosition = Vector3.zero;
        button_check.transform.localPosition = spawnPosition.position;
       // CheckButtonClick CheckButtonClick = FindObjectOfType<CheckButtonClick>();
        button_cencel = this.CreateBtnModel(this.prefab_button_cencel);
        //Info
        button_cencel.transform.SetParent(Canvas.transform, false);
        //model.transform.localPosition = Vector3.zero;
        button_cencel.transform.localPosition = spawnPosition.position;
        button_check.onClick.AddListener(CheckClick);
        button_cencel.onClick.AddListener(CencelClick);
    }
    //private Button CreateBtnShell()
    //{
    //    return new Button(this.prefab_button_check);
    //}
    private void CheckClick()
    {
        Destroy(button_check, 0.1f);
        Destroy(button_cencel, 0.1f);
        Destroy(Building, 0.1f);
    }
    private void CencelClick()
    {
        Destroy(button_check, 0.1f);
        Destroy(button_cencel, 0.1f);
        Destroy(Building, 0.1f);
    }
    private Button CreateBtnModel(Button button)
    {
        return Instantiate(button);
    }


    private GameObject CreateBuildingShell()
    {
        return new GameObject("Building");
    }
    private GameObject CreateBuildingModel()
    {
        return Instantiate<GameObject>(this.prefab_building);
    }

    private GameObject GetClickedObject()
    {
        //충돌이 감지된 영역
        RaycastHit hit;
        //찾은 오브젝트
        GameObject target = null;

        //마우스 포이트 근처 좌표를 만든다.
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //마우스 근처에 오브젝트가 있는지 확인
        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            //있다!
            
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        Debug.Log("target = " + target);
        return target;
    }
    //public void OnClickBdgBtn1()
    //{

    //}
}
