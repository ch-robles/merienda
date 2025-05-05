using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float howClose;
    public Transform head, barrel;    
    public GameObject _projectile;
    public float fireRate, nextFire;
    public float rotationSpeed = 5f;

    private int shotsFired = 0; // Track shots

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose && shotsFired < 2)
        {
            // Aim from barrel toward player
            Vector3 targetPoint = _Player.position + Vector3.up * -1.4f;
            Vector3 directionToPlayer = (targetPoint - barrel.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            head.rotation = Quaternion.Slerp(head.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                shoot();
            }

            Debug.DrawLine(barrel.position, _Player.position, Color.red);
        }
    }

    void shoot()
    {
        if (shotsFired >= 2) return;

        GameObject clone = Instantiate(_projectile, barrel.position, head.rotation);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(head.forward * 5000);
        }
        Destroy(clone, 7f);

        shotsFired++; // Increment shot counter
    }
}