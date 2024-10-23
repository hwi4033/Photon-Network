using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidBody;

    void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        rotation.InputRotateY();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        move.Movement(rigidBody);

        rotation.RotateY(rigidBody);
    }

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}