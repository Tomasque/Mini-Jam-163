using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [SerializeField] float despawnDelay;
    [SerializeField] float shrinkDuration;

    private void Awake()
    {
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnDelay);

        Vector3 fullSize = transform.localScale;

        for(float t = 0; t < shrinkDuration; t += Time.deltaTime)
        {
            float x = t / shrinkDuration;
            transform.localScale = Vector3.Lerp(fullSize, Vector3.zero, x);

            yield return new WaitForSeconds(0);

        }

        Destroy(gameObject);
    }
}
