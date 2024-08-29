using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterBehaviour : MonoBehaviour
{
    public bool _canMove;
    [SerializeField] private bool _isCorrutineRuning;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector3 _force;
    [SerializeField] private PlayerController _playerController;


    private void OnEnable()
    {
        _isCorrutineRuning = false;
        _canMove = true;
    }

    private void FixedUpdate()
    {
        if (!_isCorrutineRuning)
        {
            if (_canMove)
            {
                StopCoroutine(MoveWatter());
                StartCoroutine(MoveWatter());
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                StopAllCoroutines();
            }
            
        }
    }

    private IEnumerator MoveWatter()
    {
        _isCorrutineRuning = true;
        yield return new WaitForSeconds(_moveTime);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_force, ForceMode.Force);
        yield return null;
        _isCorrutineRuning = false;
        yield return null;
    }


    private void OnTriggerEnter(Collider other)
    {
        BridgeController temp = null;
        if (other.tag == "Bridge")
        {
            if (other.name == "RightPart" || other.name == "LeftPart")
            {
                temp = other?.GetComponentInParent<BridgeController>();
                temp.OnDestroyBridge.Invoke(temp); 
            }
        }

        if (other.tag == "Spawn")
            Destroy(other.gameObject);

        if (other.tag == "Player")
        {
            _playerController.DestroyPlayer();
            _canMove = false;
        }
    }
}