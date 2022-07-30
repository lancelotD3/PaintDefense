using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Enemy parent;
    private Animator animator;

    private void Awake()
    {
        parent = GetComponentInParent<Enemy>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("X", parent.GetMoveDirectionX());
        animator.SetFloat("Y", parent.GetMoveDirectionY());
    }
}
