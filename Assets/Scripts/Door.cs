using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    [SerializeField]
    Object sceneToLoad;

    string sceneName;

    public static GameObject characterToEnter;

	// Use this for initialization
	void Start () {
        sceneName = sceneToLoad.name;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        characterToEnter = collision.gameObject;
        SceneManager.LoadScene(sceneName);
        
    }

}
