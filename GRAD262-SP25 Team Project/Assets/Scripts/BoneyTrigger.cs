using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DracarysInteractive.AIStudio;

public class BoneyTrigger : DialogueTrigger
{
    public Transform go1, go2;
    public float triggerDistance = 2f;
    public bool triggerNear = true;

    void Update()
    {
        if (Triggered)
            return;

        float distance = Vector3.Distance(go1.position, go2.position);

        if ((triggerNear && distance < triggerDistance) || (!triggerNear && distance > triggerDistance)) {
            go2.gameObject.SetActive(true);
            OnTrigger();
        }
    }
}
