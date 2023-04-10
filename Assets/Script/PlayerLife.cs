using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
     Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pengui"))
        {
            //score.lives--;
            SceneManager.LoadScene(_scene.name);
        }
;
    }
}
