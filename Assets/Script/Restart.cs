using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject GameOver;

    private bool Finish = false;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || Finish == true)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameOver.SetActive(true);
        }

        if (Finish == true && Input.GetKeyDown("g"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SetTrue() { Finish = true; }
}
