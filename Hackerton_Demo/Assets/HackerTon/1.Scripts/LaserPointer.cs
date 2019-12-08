using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType = SteamVR_Input_Sources.RightHand;

    public SteamVR_Behaviour_Pose controllerPose;

    public SteamVR_Action_Boolean teleportAction;

    public GameObject Player;
    public GameObject laserPrefabs;
    private GameObject laser;

    private Transform laserTransform;

    private Vector3 ReturnPos;
    private Vector3 hitPoint;

    int btnClickCount = 0;
    float damp = 6.0f;

    bool laststate = false;
    bool laststatedown = false;
    bool laststateup = false;

    // Start is called before the first frame update
    void Start()
    {
        
        laser = Instantiate(laserPrefabs);
        //Debug.Log("laser instantiate");
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(btnClickCount);

        laststate = false;
        laststate = teleportAction.GetLastState(handType);

        laststatedown = false;
        laststatedown = teleportAction.GetLastStateDown(handType);

        laststateup = false;
        laststateup = teleportAction.GetLastStateUp(handType);

        //Debug.Log(laststate);
        //Debug.Log(laststatedown);
        //Debug.Log(laststateup);

        if (teleportAction.GetState(handType)) // 버튼 누를 때 //teleportAction.GetState(handType)
        {
            RaycastHit hit;

            if(Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100)) // 레이져 직선 방향으ㅜ로 쏘기
            {
                hitPoint = hit.point;
                //Debug.Log("laser hit");
                showLaser(hit);

                if(hit.collider.tag == "Animal") // 동물이랑 레이저랑 부딪히면
                {
      
                    Rigidbody rigidbody = hit.rigidbody.GetComponent<Rigidbody>(); // 부딪힌 동물의 중력 가죠오기
                    Transform AnimalTransform = hit.collider.GetComponent<Transform>(); // 부딪힌 동물의 위치 값 가져오기

                    if (teleportAction.changed && btnClickCount == 0)
                    {
                        AnimalTransform.gameObject.AddComponent<testRotate>();
                        btnClickCount = 1;
                    }
                    else if (teleportAction.changed && btnClickCount == 1)
                    {
                        testRotate rotateScript = AnimalTransform.gameObject.GetComponent<testRotate>();
                        Destroy(rotateScript);
                        if (!rotateScript)
                        {
                            rigidbody.useGravity = true;
                        }

                        btnClickCount = 0;
                        //Debug.Log("testrotate 삭제");

                        if (rigidbody.useGravity == false)
                        {
                            rigidbody.useGravity = true;
                            //Debug.Log("그래비티 사용!");
                        }

                    }
                }
            }
            else
            {
                laser.SetActive(false);
            }
        }
        else
        {
            laser.SetActive(false);
        }

    }

    private void showLaser(RaycastHit hit)
    {
        //Debug.Log("laser work");
        laser.SetActive(true);
        laser.transform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, 0.5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }
/*
    IEnumerator DestoryScript(Transform AnimalTrans)
    {
        yield return new WaitForSeconds(2f);
        testRotate rotateScript = AnimalTrans.gameObject.GetComponent<testRotate>();
        Destroy(rotateScript);
        btnClickCount = 0;
    }
*/
}
