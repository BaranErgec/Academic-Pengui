using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb2;
    [SerializeField] int jumpPower;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.35f, 0.86f), CapsuleDirection2D.Horizontal, 0, groundLayer);


        if  (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpPower);
        }
    }

}
