using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            foreach (var gameObj in GameObject.FindGameObjectsWithTag(other.gameObject.tag))
            {
                Destroy(gameObj);
            }
    }
}
