using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
 Transform _Player;
    public float howClose = 10f;
    public GameObject _projectile;
    public float fireRate = 1f;
    float nextFire;
//
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (_Player == null)
        {
            Debug.LogError("Player not found! Make sure the player is tagged 'Player'");
        }
    }

    void Update()
    {
        if (_Player == null) return;

        float dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(_projectile, transform.position, Quaternion.identity);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (_Player.position - transform.position).normalized;
            rb.AddForce(direction * 5000f);
        }
        Destroy(clone, 7f);
    }
}
