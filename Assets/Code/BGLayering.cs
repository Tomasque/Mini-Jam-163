using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLayering : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> backgrounds;

    private void Awake()
    {
        foreach (SpriteRenderer b in backgrounds)
        {
            b.sortingOrder = Ref.levelPan.cakeBackgroundLayer;
        }
        Ref.levelPan.cakeBackgroundLayer++;
    }
}
