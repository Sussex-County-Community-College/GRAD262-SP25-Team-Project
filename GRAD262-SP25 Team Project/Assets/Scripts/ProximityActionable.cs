using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityActionable : MonoBehaviour
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

    public virtual void DoAction()
    {
        Debug.Log("Entered DoAction");
    }
}
