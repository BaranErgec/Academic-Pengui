using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public bool slide;

    public bool grounded = true;

    public SpriteRenderer SR;

    public Rigidbody2D rb2;

    public Animator anim;

    public EdgeCollider2D regularColl;
    public EdgeCollider2D slideColl;
    public float slideSpeed = 3.0f;

    private void Update()
    {
        if ((grounded == true && Input.GetKey(KeyCode.S)))
            prefromSlide();
    }
    private void prefromSlide()
    {
        slide = true;
        anim.SetBool("slide", true);

        regularColl.enabled = false;
        slideColl.enabled = true;

        if (SR.flipX)
        {
            rb2.AddForce(Vector2.left * slideSpeed);
        }
        else
        {
            rb2.AddForce(Vector2.right * slideSpeed);
        }

        StartCoroutine("stopSlide");
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        anim.Play("IdleAnim");
        anim.SetBool("slide", false);

        regularColl.enabled = true;
        slideColl.enabled = false;
        slide = false;
    }








}
