using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActionable : Actionable
{
    public GameObject chest;
    private SpriteRenderer spriteRenderer;
    public Sprite openChest;
    public GameObject player;

    private void Awake()
    {
        spriteRenderer = chest.GetComponent<SpriteRenderer>();
    }
    public override void DoAction()
    {
        spriteRenderer.sprite = openChest;
    }
}
