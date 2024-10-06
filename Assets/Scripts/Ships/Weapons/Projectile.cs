﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _timeToLive = 2f;

        public string Id => _id.Value;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidbody2D.velocity = transform.up * _speed;
            StartCoroutine(DestroyInSeconds(_timeToLive));
        }
        
        private IEnumerator DestroyInSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}