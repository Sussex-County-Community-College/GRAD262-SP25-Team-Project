using UnityEngine;
using UnityEngine.UI;

public class BurnButton : MonoBehaviour
{
    public int currentBurn = 0;
    public int maxBurn = 4;

    public Sprite[] BurnLevels;
    public Image BurnLevel; // Reference to the UI Image whose sprite will change

    // once the button is pressed, the sprite will change to the next Burn level
    public void OnButtonPress()
    {
        currentBurn++;
        if (currentBurn >= maxBurn)
        {
            currentBurn = 0;
        }
        UpdateSprite();
    }

    public void OnButtonPressDown()
    {
         currentBurn--;
          if (currentBurn < 0)
          {
              currentBurn = maxBurn - 1;
          }
          UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (BurnLevel != null)
        {
            BurnLevel.sprite = BurnLevels[currentBurn];
        }

        else
        {
            Debug.LogError("Image component is missing.");
        }
    }

    public void ResetSprite()
    {
        BurnLevel.sprite = BurnLevels[0];
    }

}
