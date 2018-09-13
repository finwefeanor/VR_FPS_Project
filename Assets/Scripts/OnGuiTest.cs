using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGuiTest : MonoBehaviour {

    public GameObject GO;
    public Texture image;

    void OnGUI() {
        //if (GUI.Button(new Rect(10, 10, 100, 30), "Enable")) //creates gui button 
        //{
        //    Debug.Log("Enable: " + GO.name);
        //    GO.SetActive(true);
        //}
        //if (GUI.Button(new Rect(10, 50, 100, 30), "Disable"))
        //{
        //    Debug.Log("Disable: " + GO.name);
        //    GO.SetActive(false);
        //}

        GUI.DrawTexture(new Rect(10, 10, 100, 30), image);
    }
}
