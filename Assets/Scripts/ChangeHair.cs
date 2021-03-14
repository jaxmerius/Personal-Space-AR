using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeHair : MonoBehaviour
{
    public Button HairButton;
    public RawImage DropDownMenu;

    public Sprite BlondeHair;
    public Sprite BrownHair;
    public Sprite BlackHair;

    public void ChangeHairColor(string hair)
    { 
        Vector2 finalPos = new Vector2(0, 1920);
        DropDownMenu.transform.localPosition = finalPos;

        switch (hair)
        {
            case "Blonde Hair":
                HairButton.GetComponent<Image>().sprite = BlondeHair;
                break;

            case "Brown Hair":
                HairButton.GetComponent<Image>().sprite = BrownHair;
                break;

            case "Black Hair":
                HairButton.GetComponent<Image>().sprite = BlackHair;
                break;
        }
   
    }

}
