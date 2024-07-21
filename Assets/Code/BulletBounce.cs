using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tags T = collision.gameObject.GetComponent<Tags>();

        if (T == null || !T.blocksBullets)
            return;

        transform.eulerAngles *= -1f;
    }
}
