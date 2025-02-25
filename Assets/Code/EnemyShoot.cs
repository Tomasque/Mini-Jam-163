using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float shootDelay;
    [SerializeField] GameObject bullet;
    [SerializeField] bool offbeat;
    [SerializeField] List<Transform> shootSpots;
    int index;
    float d;

    private void Awake()
    {
        if (offbeat)
            d = shootDelay / 2f;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(d);
        d = 0;

        GameObject b = Instantiate(bullet, shootSpots[index].position, transform.rotation, transform);
        b.transform.localScale = new Vector3(b.transform.localScale.x * Mathf.Sign(transform.lossyScale.x), b.transform.localScale.y, 1);

        index++;
        if (index >= shootSpots.Count)
            index = 0;

        yield return new WaitForSeconds(shootDelay);

        StartCoroutine(Shoot());
    }
}
