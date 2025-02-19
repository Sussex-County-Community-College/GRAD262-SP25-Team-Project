using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActionable : Actionable
{
    public Transform destination;
    public GameObject player;
    
    public override void DoAction()
    {
        player.transform.position = destination.transform.position;
    }
}
