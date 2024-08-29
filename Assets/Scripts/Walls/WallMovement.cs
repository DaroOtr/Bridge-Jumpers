using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 pos;

    private void OnEnable()
    {
        pos = transform.position;
    }

    private void LateUpdate()
    {
        pos.y = _player.transform.position.y;
        transform.position = pos;
    }
}