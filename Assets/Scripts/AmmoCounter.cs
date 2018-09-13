using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    int ammoScore;
    Text ammoText;

    RifleFire rifleFire;
    GameObject rifle;

    void Start() {
        rifle = GameObject.Find("Rifle");
        ammoText = GetComponent<Text>();
        rifleFire = rifle.GetComponent<RifleFire>();
    }

    void Update() {
        ammoText.text = "Ammo: " + rifleFire.currentAmmo.ToString();
    }
}
