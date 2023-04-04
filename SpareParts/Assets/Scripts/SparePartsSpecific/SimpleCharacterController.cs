using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public AudioSource footstepSound;
    public Animator animator;
    private CharacterController characterController;
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Compute wasd axes / movement
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        float isMoving = Mathf.Abs(Horizontal) + Mathf.Abs(Vertical);

        //Update Animations
        animator.SetFloat("isMoving", isMoving);
        animator.SetFloat("Horizontal", Horizontal);
        animator.SetFloat("Vertical", Vertical);

        //Play Footstep sound
        if (isMoving>0)
        {
            footstepSound.enabled = true;
        } else
        {
            footstepSound.enabled = false;
        }

        //Move Character
        Vector3 move = new Vector3(Horizontal, 0, Vertical);
        characterController.Move(move * Time.deltaTime * Speed);
        
    }
}
