using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriger : MonoBehaviour
{
    public GameObject objC;
    public GameObject objH;
    public GameObject objO;

    // Start is called before the first frame update
    void Start()
    {
        Collider firstCol = GetComponent<Collider>();
        Collider secondCol = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (objC.tag == "AtomC")
        {
            
        }
    }
}
