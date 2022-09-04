using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arba�caAnim : MonoBehaviour
{
    private Arba�ca parent;
    private Animator animator;
    private float rotation = 0;
    private void Awake()
    {
        parent = GetComponentInParent<Arba�ca>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rotation = parent.GetAngle() / 360;
        animator.SetFloat("rotation", rotation);
    }
}
