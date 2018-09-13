using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void Start() {
        Invoke("MainSceneLevel", 2f);
    }

    void MainSceneLevel() {
        SceneManager.LoadScene(0);
    }
}
