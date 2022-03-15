using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(animInfo.IsName("Base")){
            if (Input.GetKeyDown(KeyCode.J)) anim.SetTrigger("Punch");
            if (Input.GetKeyDown("space")) anim.SetTrigger("Jump");
        }
        if(Input.GetKey(KeyCode.D)) {
            anim.SetInteger("Condition", 2);
        }
        if (Input.GetKey(KeyCode.A)) {
            anim.SetInteger("Condition", 3);
        }
        if(!(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.D) )){
            anim.SetInteger("Condition", 0);
        }
    }
}
