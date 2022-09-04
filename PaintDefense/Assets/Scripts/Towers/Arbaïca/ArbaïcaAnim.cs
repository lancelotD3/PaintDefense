using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbaïcaAnim : MonoBehaviour
{
    private ArbaÏca parent;
    private Animator animator;
    private float rotation = 0;
    private void Awake()
    {
        parent = GetComponentInParent<ArbaÏca>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rotation = parent.GetAngle() / 360;
        animator.SetFloat("rotation", rotation);
    }
}
