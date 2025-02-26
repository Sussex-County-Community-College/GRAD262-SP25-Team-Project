using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActionable : Actionable
{
    public Transform destination;
    public GameObject door;
    private SpriteRenderer spriteRenderer;
    public Sprite openDoor;
    public GameObject player;

    private void Awake()
    {
        spriteRenderer = door.GetComponent<SpriteRenderer>();
    }
    public override void DoAction()
    {
        player.transform.position = destination.transform.position;
        AudioManager.instance.PlayDoorOpening();
        spriteRenderer.sprite = openDoor;
    }
}
