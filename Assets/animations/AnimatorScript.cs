using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public Animator playerAnimation;
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { playerAnimation.SetBool("isWalking", true); }
        else { playerAnimation.SetBool("isWalking", false); }

        if (Input.GetKey(KeyCode.S))
        { playerAnimation.SetBool("isWalkBack", true); }
        else { playerAnimation.SetBool("isWalkBack", false); }
    }
}
