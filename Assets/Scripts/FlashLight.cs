using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour 
{
    [SerializeField] bool isNotInRange;

    [SerializeField] Light flashLight;
    [SerializeField] AudioClip flashLightSound;
    Camera fpsCam;
    
    void Start() {
        flashLight = GetComponentInChildren<Light>();
        fpsCam = GetComponentInParent<Camera>();            
    }

    void Update()
    {
        if (fpsCam.transform.eulerAngles.z <= 360f && fpsCam.transform.eulerAngles.z > 335f) //opposite range check
        {
            isNotInRange = true;        // means we are not in the flashlight's roll range.
        }
        else if(isNotInRange) // if "isNotInRange" is true then we can run flashlight
        {
            FlashLightControl();
        }
    }

    void FlashLightControl() 
    {
        if (fpsCam.transform.eulerAngles.z <= 335f && fpsCam.transform.eulerAngles.z > 285f) // the range we want to run flashligt
        {
            isNotInRange = false; // we are in the range.
            ToggleFlashLight();
        }
    }

    void ToggleFlashLight() 
    {
        flashLight.enabled = !flashLight.enabled;
        PlayFlashLightSound();
    }
    
    void PlayFlashLightSound() 
    {
        AudioSource audioSource = GetComponentInParent<AudioSource>();
        audioSource.PlayOneShot(flashLightSound);
    }
}
