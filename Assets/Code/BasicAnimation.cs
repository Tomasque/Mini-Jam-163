using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : MonoBehaviour
{
    [SerializeField] List<GameObject> frames;
    [SerializeField] List<float> durations;

    private void Awake()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        for(int i = 0; i < frames.Count; i++)
        {
            frames[i].SetActive(true);

            yield return new WaitForSeconds(durations[i]);

            frames[i].SetActive(false);
        }

        frames[0].SetActive(true);

        StartCoroutine(Animate());
    }
}
