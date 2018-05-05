using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocationData : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.SpawnPlayer();
        //GameManager.Load();
    }

}
