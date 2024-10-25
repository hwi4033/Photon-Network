using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    WALK,
    ATTACK,
    DIE
}

public class Rake : MonoBehaviourPunCallbacks
{
    [SerializeField] State state;
    [SerializeField] Animator animator;
    [SerializeField] GameObject destination;
    [SerializeField] NavMeshAgent navMeshAgent;

    void Awake()
    {
        animator = GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        destination = GameObject.Find("Nexus");

        state = State.WALK;
    }

    void Update()
    {
        switch (state)
        {
            case State.WALK     : Walk();
                break;
            case State.ATTACK   : Attack();
                break;
            case State.DIE      : Die();
                break;
        }
    }

    public void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);

        transform.LookAt(destination.transform.position);
    }

    public void Attack()
    {
        animator.Play("Attack");
    }

    public void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nexus"))
        {
            state = State.ATTACK;
        }
    }
}