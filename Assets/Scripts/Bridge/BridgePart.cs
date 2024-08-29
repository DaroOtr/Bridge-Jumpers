using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePart : MonoBehaviour
{
    [SerializeField] private bool isColliding;
    [SerializeField] private bool isAHalfBridge;
    public Rigidbody _rigidbody;


    private void Start()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
        if (isAHalfBridge)
            _rigidbody.isKinematic = true;
    }

    public bool IsColliding
    {
        get { return isColliding; }
        private set { isColliding = value; }
    }

    public void BridgePartReset()
    {
        isColliding = false;
        _rigidbody.isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{nameof(this.gameObject)} is Colliding Whit : {other.collider.gameObject.tag}");
        if (other.collider.gameObject.tag == "Bridge")
        {
            isColliding = true;
            _rigidbody.isKinematic = true;
        }

      
    }
}