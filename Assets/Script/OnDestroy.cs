using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    public Restart script;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            script.GetComponent<Restart>().SetTrue();
    }
}
