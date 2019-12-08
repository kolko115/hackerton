using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomManager:MonoBehaviour
{
    public int c = 0;
    public int h = 0;
    public int o = 0;

    public GameObject result;

    public void Start()
    {
        
    }
    public void Update()
    {
        
        if (c>=1 && o >= 1)
        {
            GameObject CO = GameObject.Find("Result").transform.Find("CO").gameObject;
            CO.SetActive(true);
        }
    }
}
