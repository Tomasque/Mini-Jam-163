using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] Vector2 randomX;

    private void Awake()
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        if(randomX.x !=0 && randomX.y != 0)
        {
            x = Random.Range(randomX.x,randomX.y);
        }

        transform.localPosition = new Vector3(x, y, 0);
    }
}
