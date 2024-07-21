using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool ignoreBoundary;

    private void Update()
    {
        transform.position += transform.right * speed * Mathf.Sign(transform.localScale.x) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tags T = collision.gameObject.GetComponent<Tags>();

        if (T == null || !T.patrolBorder || ignoreBoundary)
            return;

        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, 1);
    }
}
