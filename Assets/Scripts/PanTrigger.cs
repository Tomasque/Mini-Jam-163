using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTrigger : MonoBehaviour
{
    public void Activate()
    {
        Ref.levelPan.TriggerPanUp(transform);
        Destroy(this);
    }
}
