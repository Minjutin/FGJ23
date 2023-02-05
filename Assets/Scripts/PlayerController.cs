using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100.0f, Spin = 1.0f, verticalInput, horizontalInput;

    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;

    //Get collider
    Collider other;
    bool entered;

    Animator anim;

    void Start()
    {
        orientation = this.transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        anim = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.position =  new Vector3(transform.position.x,-8,transform.position.z);
        entered = false;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.anyKey)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && entered)
        {
            StartCoroutine(FindObjectOfType<GameManager>().Open2D(other));
            StartCoroutine(BasicLerp(this.gameObject, transform.position, transform.position + new Vector3(0, 25, 0), 0.3f));
        }
    }

    private void MovePlayer()
    {

        rb.AddForce(-orientation.right*verticalInput*moveSpeed, ForceMode.Acceleration);
        transform.Rotate(Vector3.up * Spin * horizontalInput*Time.deltaTime);

        if (verticalInput ==0)
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnTriggerEnter(Collider _other)
    {

        other = _other;
        entered = true;       
    }

    private void OnTriggerExit(Collider _other)
    {
        entered = false;
    }

    public IEnumerator BasicLerp(GameObject objectToLerp, Vector3 start, Vector3 end, float lerpDuration)
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {

            objectToLerp.transform.position = Vector3.Lerp(start, end, timeElapsed / lerpDuration);

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        objectToLerp.transform.position = end;
    }

}
