using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscarePrefab;        // Prefab that contains both model + camera
    public GameObject enemy;
    public GameObject player;                 // Reference to player
    public CinemachineVirtualCamera playerVCam;
    public PlayerController playerMovementScript;// Movement script to disable
    public AudioClip jumpscareSound;  // Assign in inspector

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) {
            hasTriggered = true;
            // TriggerJumpscare(other.gameObject);
            EndScene(other.gameObject);
        }
    }

    void EndScene(GameObject tikbalang)
    {
        TriggerJumpscare(tikbalang);
        // TriggerJumpscare(null);
        // SceneChanger.instance.ChangeScene("MainMenu");
    }

    void TriggerJumpscare(GameObject player)
    {
        if (player == null)
        {
            return;
        }

        // Disable enemy
        if (enemy != null) 
            enemy.SetActive(false);

        // Disable player visuals & control
        if (playerMovementScript != null) 
            playerMovementScript.enabled = false;
        if (player != null) 
            player.SetActive(false);

        // Make sure main camera's CinemachineBrain does an instant cut
        var brain = Camera.main.GetComponent<CinemachineBrain>();
        if (brain != null) {
            brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            brain.m_DefaultBlend.m_Time  = 0f;
        }

        // Deactivate your normal vcam
        if (playerVCam != null)
            playerVCam.gameObject.SetActive(false);

        if (jumpscareSound != null) {
            AudioSource.PlayClipAtPoint(jumpscareSound, player.transform.position);
        }

        // Instantiate jumpscare prefab at player's position
        GameObject inst = Instantiate(jumpscarePrefab, player.transform.position, Quaternion.identity);
        inst.SetActive(true);
        foreach (Transform t in inst.transform) t.gameObject.SetActive(true);

        // Find & configure the jumpscare Virtual Camera
        var vcam = inst.GetComponentInChildren<CinemachineVirtualCamera>(true);
        if (vcam != null) {
            vcam.gameObject.SetActive(true);
            vcam.Priority = 100;

            // Remove any smoothing components (Transposer/Composer)
            var trans = vcam.GetCinemachineComponent<CinemachineTransposer>();
            if (trans != null) trans.m_BindingMode = CinemachineTransposer.BindingMode.LockToTarget;

            var comp = vcam.GetCinemachineComponent<CinemachineComposer>();
            if (comp != null) comp.m_TrackedObjectOffset = Vector3.zero;
        } else Debug.LogWarning("No camera found in jumpscare prefab!");
    }
}
