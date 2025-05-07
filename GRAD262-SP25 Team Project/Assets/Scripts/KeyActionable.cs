using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCCC
{
    public class KeyActionable : Actionable
    {
        private SpriteRenderer spriteRenderer;
        public GameObject spikeGO;
        public int spikeIndex = 0;
        public Sprite[] spikes;

        private void Awake()
        {
            spriteRenderer = spikeGO.GetComponent<SpriteRenderer>();
        }
        public override void DoAction()
        {
            spikeIndex = (spikeIndex + 1) % spikes.Length;
            spriteRenderer.sprite = spikes[spikeIndex];
        }
    }
}