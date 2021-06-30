using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempActionScript : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;

    void OnMouseOver()
    {
        animator.SetBool("IsHovering", true);
    }

    void OnMouseDown()
    {
        animator.SetTrigger("Clicked");
    }

    void OnMouseExit()
    {
        animator.SetBool("IsHovering", false);
    }
}
