using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rotation))]

public class Head : MonoBehaviourPunCallbacks
{
    private Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        rotation.RotateX();
    }
}