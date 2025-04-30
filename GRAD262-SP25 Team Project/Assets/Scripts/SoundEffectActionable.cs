using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEffectActionable : ProximityActionable
{
    public AudioClip clip;
    // public ParticleSystem fx;
    
    public override void DoAction()
    {
        AudioManager.instance.PlaySoundEffect(clip);
        // fx.Play();
    }
}
