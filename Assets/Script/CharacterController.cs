using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    Animator _animator;

    Rigidbody2D _rigidbody2D;

    SpriteRenderer _spriteRenderer;

    public bool grounded;
    public bool attack;
    bool jump;
    bool walk;
    

    float moveDirection;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        grounded = true;

    }

    private void FixedUpdate()
    {

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);


    }



    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed", speed);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }
        
        if (grounded == true && Input.GetKey(KeyCode.E))
        {
            attack = true;

            _animator.SetTrigger("attack");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("grounded", true);
            grounded = true;
        }
        
        
    }

}
