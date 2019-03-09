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
        OnDrawGizmosSelected();
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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].name!="Nose" && hitColliders[i].name != "Player" && hitColliders[i].name != "Cube")
                Debug.Log(hitColliders[i].name);
            Debug.DrawLine(transform.position, hitColliders[i].transform.position, Color.red);
            if (hitColliders[i].name == "Fish") hitColliders[i].gameObject.isFroze=true;
            //hitColliders[i].SendMessage("AddDamage");
            i++;
        }
        //FishMovement.isFroze = false;
    }
    private void FixedUpdate() {
        myRigidBody.velocity = moveVelocity;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 1);
    }
}
