using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Transform _gunOffset;
    [SerializeField] private float _timeBetweenShots = 0.2f;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime = -999f;

    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;
            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        if (_bulletPrefab == null || _gunOffset == null) return;
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = _bulletSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;
        if (inputValue.isPressed) _fireSingle = true;
    }
}
