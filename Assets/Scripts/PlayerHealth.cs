using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("a");

        Tags T = collision.gameObject.GetComponent<Tags>();
        if (T == null || !T.harms)
            return;

        print("b");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
