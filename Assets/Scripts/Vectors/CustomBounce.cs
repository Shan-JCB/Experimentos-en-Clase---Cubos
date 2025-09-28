using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomBounce : MonoBehaviour
{
    [Range(0, 2f)]
    public float bounceFactor = 0.8f;
    private Rigidbody _rigidbody;
    private Vector3 _lastVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _lastVelocity = _rigidbody.velocity;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        Vector3 reflectedVelocity = Vector3.Reflect(_lastVelocity, normal);
        _rigidbody.AddForce(reflectedVelocity * bounceFactor, ForceMode.VelocityChange);
    }
}
