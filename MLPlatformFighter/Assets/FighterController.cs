using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public float speed = 10f;
    Animator anim;
    Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
       // if(animInfo.IsName("Base")){
            // Punch (J)
        if(animInfo.IsName("Base")) anim.SetBool("Fight", false);
        if(!anim.GetBool("Fight")){
            if (Input.GetKeyDown(KeyCode.J)){
              anim.SetBool("Fight", true);
              anim.SetTrigger("Punch");

            } 
            // Leg sweep (K)
            if (Input.GetKeyDown(KeyCode.K)){
                anim.SetTrigger("Leg sweep"); 
            }
            // Jump
            if (Input.GetKeyDown("space")) anim.SetTrigger("Jump");        
        // }
        // move right
        if(Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector3(speed, 0, 0);
            anim.SetInteger("Condition", 2);

        }
        // move left
        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector3(-speed, 0, 0);
            anim.SetInteger("Condition", 3);
        }
        // Crouch
        if(Input.GetKey(KeyCode.S)){
            rb.velocity = Vector3.zero;
            anim.SetInteger("Condition", 4);
            // Crouch punch
            if(Input.GetKeyDown(KeyCode.J)) anim.SetTrigger("Crouch punch");
        }
        // stop move
        if(!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.S)){
            rb.velocity = Vector3.zero;
            anim.SetInteger("Condition", 0);
        }
        // Zero velocity if attacking
        if(animInfo.IsName("Punching") || animInfo.IsName("Leg Sweep")){
            rb.velocity = Vector3.zero;
        }
    }
    }
}
