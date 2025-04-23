using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinMax : MonoBehaviour
{
    public int minEquip = 0;
    public int maxEquip;// Assuming maxEquip is 3 for the sake of this example
    public int totalEquip;

    public TextMeshProUGUI equipTotal;
    public TextMeshProUGUI equipMax;

    private bool initialized = false;

    private void LateUpdate()
    {
        if (!initialized)
        {
            UpdateEquip();
            initialized = true;
        }
    }

    // Call this method whenever the SlashLV image array changes
    public void UpdateEquip()
    {
        totalEquip++;
        SlashButton slashButton = FindObjectOfType<SlashButton>();
        FreezeButton freezeButton = FindObjectOfType<FreezeButton>();
        BurnButton burnButton = FindObjectOfType<BurnButton>();
        SpinButton spinButton = FindObjectOfType<SpinButton>();
        if (spinButton != null && spinButton.currentSpin >= maxEquip)
        {
            totalEquip -= 3; // Reset to 0 if it exceeds maxEquip
        }
        if (burnButton != null && burnButton.currentBurn >= maxEquip)
        {
            totalEquip -= 3; // Reset to 0 if it exceeds maxEquip
        }
        if (freezeButton != null && freezeButton.currentFreeze >= maxEquip)
        {
            totalEquip -= 3; // Reset to 0 if it exceeds maxEquip
        }
        if (slashButton != null && slashButton.currentSlash >= slashButton.maxSlash)
        {
            totalEquip -= 3; // Reset to 0 if it exceeds maxEquip
        }

        // Calculate totalEquip
        totalEquip = (slashButton != null ? slashButton.currentSlash : 0) +
                     (freezeButton != null ? freezeButton.currentFreeze : 0) +
                     (burnButton != null ? burnButton.currentBurn : 0) +
                     (spinButton != null ? spinButton.currentSpin : 0);


        if (totalEquip == maxEquip + 1 && (slashButton.currentSlash <= slashButton.maxSlash || freezeButton.currentFreeze <= freezeButton.maxFreeze || burnButton.currentBurn <= burnButton.maxBurn || spinButton.currentSpin <= spinButton.maxSpin))
        {
            totalEquip = 0; // Reset to 0 if it exceeds maxEquip
            slashButton.currentSlash = 0;
            freezeButton.currentFreeze = 0;
            burnButton.currentBurn = 0;
            spinButton.currentSpin = 0;
            slashButton.ResetSprite();
            freezeButton.ResetSprite();
            burnButton.ResetSprite();
            spinButton.ResetSprite();
        }
        // Update the UI text elements
        equipTotal.text = totalEquip.ToString();
        equipMax.text = maxEquip.ToString();
    }
}