using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame(int players)
    {
        Ref.players = players;

        SceneManager.LoadScene("SampleScene");
    }
}
