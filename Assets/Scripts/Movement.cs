using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float walkspeed = 2.5f, runspeed = 5, maxspeed;
    Rigidbody rbody;
    //Vector3 moveTowards;
    Vector3 speed;
    bool isAttacking;
    Animator animator;
    SpriteRenderer spriterenderer;
    GameObject player;
    const float MINDISTANCE = 1, MINENEMYCHASE = 5;
    float distance;
    // Start is called before the first frame update
    void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }



    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Enemy")
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (distance < MINENEMYCHASE && distance > MINDISTANCE)
            {
                speed = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, walkspeed *Time.deltaTime);
                isAttacking = false;
            }
            else if(distance < MINDISTANCE)
            {
                speed = Vector3.zero;
                isAttacking = true;
            }
            else
            {
                speed = Vector3.zero;
                isAttacking = false;
            }
        }
        else
        {
            
            //player
            maxspeed = Input.GetButtonDown("Fire3") ? runspeed : walkspeed;

            isAttacking = Input.GetButtonDown("Fire1");
            
            speed = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * maxspeed /*(Input.GetButtonDown("Fire3") ? runspeed : walkspeed)*/;
            //rbody.velocity =     
        }

        animator.SetFloat("moveSpeed", speed.magnitude);
        animator.SetBool("isAttacking", isAttacking);
        /*spriterenderer.flipX = speed.x < 0;  
        rbody.velocity = speed;*/

        if(gameObject.tag == "Player")
        {
            spriterenderer.flipX = speed.x < 0;
            rbody.velocity = speed;
        }
        else if (speed != Vector3.zero)
        {
            spriterenderer.flipX = player.transform.position.x < gameObject.transform.position.x;
            rbody.transform.position = speed;
        }

    }
}
