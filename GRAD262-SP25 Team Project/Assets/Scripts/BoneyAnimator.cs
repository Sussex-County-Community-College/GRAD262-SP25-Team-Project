using DracarysInteractive.AIStudio;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoneyAnimator : MonoBehaviour, IDialogueCharacterAnimator
{
    public void OnStartSpeaking(DialogueCharacter character, DialogueCharacter speaker)
    {
        speaker.GetComponent<Animator>().SetBool("speaking", true);
    }

    public void OnEndSpeaking(DialogueCharacter character, DialogueCharacter speaker)
    {
        speaker.GetComponent<Animator>().SetBool("speaking", false);
    }

    public void OnStartSpeechRecognition(DialogueCharacter character, DialogueCharacter speaker)
    {
    }

    public void OnSpeechRecognized(DialogueCharacter character, DialogueCharacter speaker)
    {
    }

    public void AnimateActions(DialogueCharacter character, string[] actions)
    {
    }
}