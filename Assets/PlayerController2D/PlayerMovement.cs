using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    Vector2 movement;
    Collider2D interactingCollider;

    public static bool rotation;
    bool canMove = true;


    public void changeMoveState(bool state)
    {
        canMove = state;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
        {
            rotation = true;
            animator.SetBool("Rotation", true);
        }
        else
        if (movement.x < 0)
        {
            rotation = false;
            animator.SetBool("Rotation", false);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(interactingCollider != null)
            {
                var inter = interactingCollider.GetComponent<Interactable>();
                if(inter)
                {
                    inter.Interact();
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if(canMove) rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        interactingCollider = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactingCollider = collision;
    }
}
