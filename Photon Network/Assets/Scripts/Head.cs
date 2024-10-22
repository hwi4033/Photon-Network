using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]

public class Head : MonoBehaviour
{
    private Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation.RotateX();
    }
}