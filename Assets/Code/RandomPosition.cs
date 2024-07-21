using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField] Vector2 randomX;
    [SerializeField] Vector2 randomY;
    [SerializeField] bool randomFacing;

    private void Awake()
    {
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;

        if(randomX.x !=0 || randomX.y != 0)
        {
            x = Random.Range(randomX.x,randomX.y);
        }

        if (randomY.x != 0 || randomY.y != 0)
        {
            y = Random.Range(randomY.x, randomY.y);
        }

        if (randomFacing)
        {
            int facing = Random.Range(0, 2) * 2 - 1;
            transform.localScale = new Vector3(transform.localScale.x * facing, transform.localScale.y, 1);
        }

        transform.localPosition = new Vector3(x, y, 0);
    }
}
