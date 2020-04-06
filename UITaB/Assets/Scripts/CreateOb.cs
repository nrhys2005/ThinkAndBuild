using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOb : MonoBehaviour
{
    public GameObject m_prefab;
    public Transform sposition;
    // Start is called before the first frame update

    public void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
            Instantiate(m_prefab, sposition.position, Quaternion.identity);
        
        return;
    }
    void create()
    {
        
    }
}
