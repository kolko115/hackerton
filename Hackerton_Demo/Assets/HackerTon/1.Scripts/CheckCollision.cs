using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{

    public Transform myTransform;

    public AtomManager a; 
    //private int 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("AtomC"))
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
           
        }
        else if (other.tag == "AtomH")
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
            
        }
        else if (other.tag == "AtomO")
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "AtomC")
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
            Debug.Log(other.tag);
            a.c++;
            

        }
        else if(other.tag == "AtomH")
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
            Debug.Log(other.tag);
            a.h++;
        }
        else if (other.tag == "AtomO")
        {
            Transform g = other.gameObject.GetComponent<Transform>();
            g.position = myTransform.position;
            Debug.Log(other.tag);
            a.o++;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
