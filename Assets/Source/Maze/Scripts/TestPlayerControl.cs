using System;
using UnityEngine;

namespace Source.Maze.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class TestPlayerControl : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Animator _animator;

        private float _vertical;
        private float _horizontal;
        
        private float _moveSpeed = 5f;
        private float _rotationSpeed = 2.5f;
        
        private readonly int vertical = Animator.StringToHash("Vertical");
        private readonly int horizontal = Animator.StringToHash("Horizontal");

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _transform = _rigidbody.transform;
        }

        private void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
            
            _animator.SetFloat(vertical, _vertical);
            _animator.SetFloat(horizontal, _horizontal);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _transform.forward * (_vertical * _moveSpeed);
            _rigidbody.angularVelocity = Vector3.up * (_horizontal * _rotationSpeed);
        }
    }
}
