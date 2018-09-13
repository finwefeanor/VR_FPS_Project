using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

    [SerializeField] Transform vrCamera;
    [SerializeField] float toggleAngle = 30f;
    [SerializeField] float speed = 3f;
    [SerializeField] bool isMovingForward;
    [SerializeField] CharacterController controller;
    [SerializeField] AudioClip[] footstepSounds;
    private AudioSource audioSource;

    void Start () 
    {
        controller = GetComponentInParent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () 
    {
        MoveForward();
	}   

    void MoveForward()
    {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90f)
        {
            isMovingForward = true;
        }
        else
        {
            isMovingForward = false;
        }

        if (isMovingForward)
        {
            Vector3 moveForward = vrCamera.TransformDirection(Vector3.forward);

            controller.SimpleMove(moveForward * speed);
            PlayFootStepAudio();
        }
    }

    private void PlayFootStepAudio() {
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];

        if (controller.isGrounded == true && controller.velocity.magnitude > 2f && audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

}
