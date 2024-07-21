using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipImage : MonoBehaviour
{
    [SerializeField] Transform image;

    private void Start()
    {
        /*
        if( Mathf.Sign(transform.lossyScale.x) == -1)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }
        */

        if(Mathf.Sign(transform.lossyScale.x) != Mathf.Sign(transform.localScale.x))
        {
            image.localScale = new Vector3(image.localScale.x * -1, image.localScale.y, 1);
        }
    }
}
