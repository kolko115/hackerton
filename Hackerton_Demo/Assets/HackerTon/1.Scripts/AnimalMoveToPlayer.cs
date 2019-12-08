using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoveToPlayer : MonoBehaviour
{
    public GameObject Animal;

    public Animator AnimalAnimator;

    public GameObject Laser;


    // Start is called before the first frame update
    void Start()
    {
        Laser = GameObject.FindGameObjectWithTag("Laser");


        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == Laser)
        {
            Debug.Log(collision);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
    