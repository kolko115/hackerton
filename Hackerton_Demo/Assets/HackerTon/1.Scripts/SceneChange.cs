using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
public class SceneChange : MonoBehaviour
{

    public Transform portalTransform;

    public Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(PlayerTransform.position);
        Debug.Log(portalTransform.position);
        if (portalTransform.position == PlayerTransform.transform.position)
        {
            SteamVR_LoadLevel.Begin("LaboratoryScene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            //SceneManager.LoadScene("LaboratoryScene");
            SteamVR_LoadLevel.Begin("LaboratoryScene");
        }
    }
}
