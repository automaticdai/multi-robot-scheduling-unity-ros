using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agent : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;    
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float moveSpeed;
    private float moveDirection;
    private Rigidbody rigidbodyComponent;


    // Start is called before the first frame update
    void Start() {
        rigidbodyComponent = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(-10f, 10f);
        moveDirection = Random.Range(-1.0f, 1.0f) * Mathf.PI; 
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate() {

        //rigidbodyComponent.AddForce(new Vector3(moveSpeed * Mathf.Sin(moveDirection), 0f, moveSpeed * Mathf.Cos(moveDirection)), ForceMode.VelocityChange);
        rigidbodyComponent.velocity = new Vector3(moveSpeed * Mathf.Sin(moveDirection), 0f, moveSpeed * Mathf.Cos(moveDirection));
        // rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    
        // if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0){
        //     return;
        // }

        // if (jumpKeyWasPressed) {
        //     rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        //     jumpKeyWasPressed = false;
        // }

    }
}
