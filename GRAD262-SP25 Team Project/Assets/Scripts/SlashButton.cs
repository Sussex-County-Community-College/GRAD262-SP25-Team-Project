using UnityEngine;
using UnityEngine.UI;
using SCCC;

public class SlashButton : MonoBehaviour
{
    public int currentSlash = 0;
    public int maxSlash = 4;

    public Sprite[] SlashLevels;
    public Image SlashLevel; // Reference to the UI Image whose sprite will change

    private void Start()
    {


        // Check if "currentSlash" exists in StatManager
        if (StatManager.Instance.GetStat("currentSlash") >= 0)
        {
            currentSlash = StatManager.Instance.GetStat("currentSlash");
        }
        else
        {
            // If no value exists, initialize it in StatManager
            StatManager.Instance.SetStat("currentSlash", currentSlash, true);
        }

        // Initialize the maxSlash stat in StatManager
        StatManager.Instance.SetStat("maxSlash", maxSlash, true);

        // Update the sprite to reflect the loaded value
        UpdateSprite();
    }

    public void OnButtonPress()
    {
        currentSlash++;
        if (currentSlash >= maxSlash)
        {
            currentSlash = 0;
        }

        // Save the updated value to StatManager
        StatManager.Instance.SetStat("currentSlash", currentSlash, true);

        UpdateSprite();
    }

    public void OnButtonRightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentSlash--;
            if (currentSlash < 0)
            {
                currentSlash = maxSlash - 1;
            }

            // Save the updated value to StatManager
            StatManager.Instance.SetStat("currentSlash", currentSlash, true);

            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        if (SlashLevel != null)
        {
            SlashLevel.sprite = SlashLevels[currentSlash];
        }
        else
        {
            Debug.LogError("Image component is missing.");
        }
    }

    public void ResetSprite()
    {
        currentSlash = 0;

        // Save the reset value to StatManager
        StatManager.Instance.SetStat("currentSlash", currentSlash, true);

        SlashLevel.sprite = SlashLevels[0];
    }
}
