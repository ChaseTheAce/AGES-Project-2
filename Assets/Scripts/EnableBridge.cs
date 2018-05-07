using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBridge : MonoBehaviour {

    [SerializeField]
    GameObject bridge;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bridge.SetActive(false);
    }
}
