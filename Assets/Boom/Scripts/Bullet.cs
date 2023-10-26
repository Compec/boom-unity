using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody => _rigidbody;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _explosion;
    
    public float radius = 5.0F;
    public float power = 10.0F;
    
    private void OnCollisionEnter(Collision other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }

        var explosion = Instantiate(_explosion);
        explosion.transform.position = explosionPos;
        Destroy(gameObject);
    }
}
