using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    public float speedDampener;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        speedDampener = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float animationThreshold = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("animationThreshold", animationThreshold, speedDampener, Time.deltaTime);
    }
}
