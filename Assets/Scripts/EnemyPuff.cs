using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPuff : MonoBehaviour
{
    [SerializeField] float waitDuration;
    [SerializeField] float growDuration;
    [SerializeField] float stayDuration;
    [SerializeField] float shrinkDuration;
    float smallSize;
    [SerializeField] float bigSize;
    int randomStart;
    float active;
    float randomWait;
    [SerializeField] float randomWaitMax;

    private void Awake()
    {
        smallSize = transform.localScale.x;
        randomStart = Random.Range(0, 4);
        randomWait = Random.Range(0, randomWaitMax);
        StartCoroutine(PuffCycle());
    }

    IEnumerator PuffCycle()
    {
        yield return new WaitForSeconds(randomWait);
        randomWait = 0;

        if (randomStart == 0)
            active = 1f;

        yield return new WaitForSeconds(waitDuration * active);

        if (randomStart == 1)
            active = 1f;

        for (float t = 0; t < growDuration * active; t += Time.deltaTime)
        {
            float x = t / growDuration;
            transform.localScale = Vector3.one * Mathf.Lerp(smallSize, bigSize, x);

            yield return new WaitForSeconds(0);
        }
        transform.localScale = Vector3.one * bigSize;

        if (randomStart == 2)
            active = 1f;

        yield return new WaitForSeconds(stayDuration * active);

        if (randomStart == 3)
            active = 1f;

        for (float t = 0; t < shrinkDuration; t += Time.deltaTime)
        {
            float x = t / shrinkDuration;
            transform.localScale = Vector3.one * Mathf.Lerp(bigSize, smallSize, x);

            yield return new WaitForSeconds(0);
        }
        transform.localScale = Vector3.one * smallSize;

        StartCoroutine(PuffCycle());
    }
}
