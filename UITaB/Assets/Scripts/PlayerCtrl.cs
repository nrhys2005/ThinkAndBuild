using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator animator;
    Vector3 target = new Vector3(8, 1.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.5f);

        
    }
    private void FixedUpdate()
    {
       
    }

    private void Move()
    {
       

      
    }
}
