using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidBody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start(){
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update(){
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane oceanPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength; 

        if(oceanPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            //transform.LookAt(pointToLook);

        }
    }
    private void FixedUpdate() {
        myRigidBody.velocity = moveVelocity;
    }
}
