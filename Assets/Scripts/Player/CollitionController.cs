using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bridge")
            _player.canJump = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Bridge")
            _player.canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bridge")
            _player.canJump = false;
    }
}
