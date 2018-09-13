using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour 
{
    private bool isFlashLightOpen = false;
    [SerializeField] bool isNotInRange;

    [SerializeField] Light flashLight;
    [SerializeField] AudioClip flashLightSound;
    Camera fpsCam;
    
    void Start() {
        isNotInRange = true;
        //isFlashLightOpen = false;
        flashLight = GetComponentInChildren<Light>();
        fpsCam = GetComponentInParent<Camera>();            
    }

    void Update()
    {
        if (fpsCam.transform.eulerAngles.z <= 360f && fpsCam.transform.eulerAngles.z > 335f) //opposite range check
        {
            isNotInRange = true;           
        }
        else if(isNotInRange)
        {
            FlashLightControl();
        }
    }

    void FlashLightControl() 
    {
        if (fpsCam.transform.eulerAngles.z <= 335f && fpsCam.transform.eulerAngles.z > 285f && isNotInRange)
        {
            isNotInRange = false;
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
