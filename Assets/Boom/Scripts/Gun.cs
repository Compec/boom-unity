using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _gunBarrel;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletUpwardSpeed;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_bullet);
            bullet.transform.parent = _gunBarrel;
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.rotation = _gunBarrel.rotation;
            bullet.Rigidbody.velocity = bullet.transform.forward * _bulletSpeed + bullet.transform.up * _bulletUpwardSpeed;
            bullet.transform.parent = null;
        }
    }
}
