using System.Collections;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    bool isFalling = false;
    float downspeed = 0;
[SerializeField] float delay;
    void OnTriggerEnter(Collider collider)
    {
        //if Player Tagged object collides with collider then fall
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartFallingWithDelay(delay)); // Adjust delay duration (1 second for my implentation) as needed
        }
    }


     IEnumerator StartFallingWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isFalling = true;
        Destroy(gameObject, 10);
    }

    void Update() {
       if(isFalling){
        downspeed += Time.deltaTime/10;
        transform.position = new Vector3(transform.position.x, 
        transform.position.y-downspeed,
        transform.position.z);
       } 
    }
}