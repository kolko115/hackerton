using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotate : MonoBehaviour
{
    public GameObject target;
    
    public Vector3 a;

    //public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Text"))
            Debug.Log(GameObject.FindGameObjectWithTag("Text"));

        target = GameObject.FindGameObjectWithTag("MainCamera");

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.useGravity = false;

        Vector3 v = transform.position;

        a = v + new Vector3(0, 5, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= 7f)
            return;

        this.transform.position = Vector3.Lerp(this.transform.position, a, 0.1f);

        //if (this.GetComponent<testRotate>())        
            
            //Debug.Log("distance value in 3");
            //Time.timeScale = 0;
            

        //else
        //{
            //Time.timeScale = 1;
            if(transform.position.y >= a.y -1)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);  //Time.timeScale * 

            this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 0.05f); //Time.timeScale *
        }
            
        //}
    }
}
