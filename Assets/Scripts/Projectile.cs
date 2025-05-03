using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public float impactForce = 5000f; // Adjust this value for the push force
   

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
    {
        CharacterController playerController = other.GetComponent<CharacterController>();
        if (playerController != null)
        {
            // Calculate the direction to push the player
            Vector3 forceDirection = (transform.position - other.transform.position).normalized;

            // Adjust the force based on the projectile's velocity
            float speedMultiplier = GetComponent<Rigidbody>().velocity.magnitude;
            float finalImpactForce = impactForce * speedMultiplier;

            // Calculate the final impact vector
            Vector3 impactVector = forceDirection * finalImpactForce;

            // Apply the impact to the player
            StartCoroutine(ApplyImpact(playerController, impactVector));
        }

        // Destroy the projectile on impact
        Destroy(gameObject);
    }
    }

    private IEnumerator ApplyImpact(CharacterController playerController, Vector3 impactVector)
    {
        float duration = 0.5f; // The duration of the impact effect
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Move the CharacterController in the direction of the impact
            playerController.Move(impactVector * Time.deltaTime);
            elapsed += Time.deltaTime;

            // Gradually reduce the impact vector to simulate a force that diminishes over time
            impactVector = Vector3.Lerp(impactVector, Vector3.zero, elapsed / duration);

            yield return null;
        }
    }
}
