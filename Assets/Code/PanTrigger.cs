using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTrigger : MonoBehaviour
{
    [SerializeField] bool dontScore;

    public void Activate()
    {
        Ref.levelPan.TriggerPanUp(transform);
        if(!dontScore)
            Ref.scoreKeeper.Increment();
        Destroy(this);
    }
}
