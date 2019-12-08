using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kikiki : MonoBehaviour
{
    public GameObject Dear;
    private Animator animator;

    private bool walk;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = Dear.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walking", true);
    }
}
