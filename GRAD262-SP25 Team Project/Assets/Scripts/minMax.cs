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


        // If any of the buttons are not interactable, then subtract 3 from maxEquip for each uninteractable button
        int nonInteractableCount = 0;
        if (slashButton != null && !slashButton.GetComponent<Button>().interactable)
        {
            nonInteractableCount++;
        }
        if (freezeButton != null && !freezeButton.GetComponent<Button>().interactable)
        {
            nonInteractableCount++;
        }
        if (burnButton != null && !burnButton.GetComponent<Button>().interactable)
        {
            nonInteractableCount++;
        }
        if (spinButton != null && !spinButton.GetComponent<Button>().interactable)
        {
            nonInteractableCount++;
        }
        int effectiveMaxEquip = maxEquip - 3 * nonInteractableCount;

        // Update the UI text elements
        equipTotal.text = totalEquip.ToString();
        equipMax.text = effectiveMaxEquip.ToString();
    }
}