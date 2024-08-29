using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] public FloatingJoystick variableJoystick;
    [SerializeField] private string animatorParam;

    private void OnEnable()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (variableJoystick != null)
        {
            Vector3 temp = Vector3.zero;
            temp.x = variableJoystick.Horizontal;
            temp.y = variableJoystick.Vertical;
            _animator.SetFloat(animatorParam,temp.magnitude - temp.z);
        }
    }
}
