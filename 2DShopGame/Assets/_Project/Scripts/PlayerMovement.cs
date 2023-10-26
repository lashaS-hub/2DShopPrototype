using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveDirection;
    private Animator _characterAnimator;
    private Action<Vector2> _skinCallback;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterAnimator = GetComponent<Animator>();
    }

    public void SetSkinCallback(Action<Vector2> skinCallback)
    {
        _skinCallback = skinCallback;
    }

    private void Update()
    {
        _moveDirection.x = Input.GetAxisRaw("Horizontal");
        _moveDirection.y = Input.GetAxisRaw("Vertical");

        _characterAnimator.SetFloat("Horizontal", _moveDirection.x);
        _characterAnimator.SetFloat("Vertical", _moveDirection.y);
        _characterAnimator.SetFloat("Speed", _moveDirection.sqrMagnitude);

        _skinCallback?.Invoke(_moveDirection);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime);
    }
}
