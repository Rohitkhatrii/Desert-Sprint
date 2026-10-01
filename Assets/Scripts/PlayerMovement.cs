using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 6f;
    private Rigidbody rb;
    [SerializeField] private float leftLimit = -4.5f;
    [SerializeField] private float rightLimit = 5.5f;
    private bool isRunning;
    private bool isGrounded = true;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private Animator anim;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(isRunning == false)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);   
        // If we solve above line it will be Translate([0,0,1] * 0.0166 * 2, Space.World) , after calculation it will be Translate([0,0,0.0332], Space.World)
        // translate simply means to move or shift position // Vector3.forward is a shorthand for (0, 0, 1) which means the player will move in the positive Z direction
        // Space.World simply means that the movement will be relative to the world space, not the local space of the player object.  

        float moveInput = Input.GetAxis("Horizontal");
        float currentX = transform.position.x;

        if (currentX <= leftLimit && moveInput < 0)     //moveInput < 0 basically to check if we are on left its very simple
        {
            moveInput = 0;                    // if we are past the left limit and trying to move left, we set moveInput to 0 to prevent further movement  
        }   
        // Block rightward movement if at or past the right limit
        else if (currentX >= rightLimit && moveInput > 0)      //moveInput > 0 basically to check if we are on right its very simple
        {
            moveInput = 0;
        }

        rb.linearVelocity = new Vector3(moveInput * playerSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.Play("Jumping");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);      //ForceMode.Impulse means apply the force as an instant explosion of momentum      
            isGrounded = false;

        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!this.enabled) return; 
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.Play("Running");
            isGrounded = true;
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.35f);
        MasterInfo.distancerun += 1;
        isRunning = false;
    }

}
