using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    Restart restartScript;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            restartScript = GameObject.FindGameObjectWithTag("Environnement").GetComponent<Restart>();

            restartScript.SetTrue();
        }
    }
}
