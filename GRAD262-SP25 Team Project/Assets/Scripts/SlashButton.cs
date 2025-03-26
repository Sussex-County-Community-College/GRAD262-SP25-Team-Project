using UnityEngine;
using UnityEngine.UI;

public class SlashButton : MonoBehaviour
{
    public int currentSlash = 0;
    public int maxSlash = 4;

    public Sprite[] SlashLevels;
    public Image SlashLevel; // Reference to the UI Image whose sprite will change

    // once the button is pressed, the sprite will change to the next slash level
    public void OnButtonPress()
    {
        currentSlash++;
        if (currentSlash >= maxSlash)
        {
            currentSlash = 0;
        }
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

}
