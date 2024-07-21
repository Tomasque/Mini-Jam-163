using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChoice : MonoBehaviour
{
    [SerializeField] List<GameObject> choices;

    private void Awake()
    {
        int r = Random.Range(0, choices.Count);
        foreach (GameObject g in choices)
        {
            g.SetActive(false);
        }
        choices[r].SetActive(true);
    }
}
