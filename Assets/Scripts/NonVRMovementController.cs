using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;


public class NonVRMovementController : MonoBehaviour {
    public float velocity ;
    //public float velocity = 0.7f;
    public CharacterController MyBody;

    private Vector3 MyStartPosition;
    private Quaternion MyStartRotation;

    //Get Wii Input
    public GameObject wiiboard;
    //Wiiでの移動時は〇をオンにする

    // Use this for initialization
    void Start()
    {
        MyStartPosition = MyBody.transform.position;
        MyStartRotation = MyBody.transform.rotation;

        //〇Find Wii Board
        //wiiboard = GameObject.Find("WiiBaranceBoardParent/WiiBalanceBoardInstance0/DisplayParent/BalanceBoardDisplay");
    }

    // Update is called once per frame
    void Update () {

        //◎VR Input
        //Quaternion headRotation = InputTracking.GetLocalRotation(VRNode.Head);
        //〇Wii Input
        //float wiiMovingForward = -wiiboard.GetComponent<WiiBalanceBoardStatusTextDisplay>().balanceBoardData.copPos.y / 50;
        //float wiiMovingSide = wiiboard.GetComponent<WiiBalanceBoardStatusTextDisplay>().balanceBoardData.copPos.x / 50;

        Vector3 moveDirection = Camera.main.transform.forward;
        moveDirection *= velocity ;
        //〇Wii
        //Vector3 moveWithWii = new Vector3(wiiMovingSide, -headRotation.x * 5, moveDirection.z);
        //◎VR move
        //Vector3 moveWithWii = new Vector3(headRotation.y * 5, -headRotation.x * 5, moveDirection.z);
        Vector3 moveWithWii = new Vector3(Input.GetAxis("Horizontal") * 0.25f, Input.GetAxis("Vertical") * 0.25f, moveDirection.z);
        //Debug.Log(moveWithWii);

        //moveDirection.y = 0.0f;
        //MyBody.transform.position += moveDirection;
        MyBody.Move(moveWithWii);
        //MyBody.Move(moveDirection);
    }
}
