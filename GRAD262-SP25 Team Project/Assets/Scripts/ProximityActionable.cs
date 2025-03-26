using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityActionable : Actionable
{
    public bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction()
    {
        Debug.Log("Entered DoAction");
    }
}
