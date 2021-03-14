using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public static CharacterCustomization Instance;

    public Button femaleHairButton;
    public Button femaleSkinButton;
    public Button femaleHandButton;
    public Button femaleEyeButton;
    public Button femaleOutfitButton;
    public Button maleHairButton;
    public Button maleSkinButton;
    public Button maleEyeButton;
    public Button maleOutfitButton;

    public RawImage[] DropDownMenus;

    //arrays to hold different sprites for each category: female
    public Sprite[] femaleLongHair;
    public Sprite[] femaleShortHair;
    public Sprite[] femaleEyes;
    public Sprite[] femaleOutfit;
    public Sprite[] femaleSkinColor;
    public Sprite[] femaleHandColor;

    //arrays to hold different sprites for each category: male
    public Sprite[] maleHair;
    public Sprite[] maleEyes;
    public Sprite[] maleOutfit;
    public Sprite[] maleSkinColor;

    //to hold sprite type values
    public string hairString;
    public string skinString;
    public string eyeString;
    public string outfitString;

    //to hold characters in ARSection
    public GameObject female;
    public GameObject male;


    private void Start()
    {
        Instance = this;
    }

    //Change the hair color, taking the string input given when button pressed
    public void ChangeHairColor(string hairColor)
    {
        //Set drop down menu's new position to off the screen
        Vector2 finalPos = new Vector2(0, 1920);
        DropDownMenus[1].transform.localPosition = finalPos;
        
        //check which gender is checked
        if(DropdownMenu.Instance.genVal == 0)
        {
            //check the string value of the button pressed
            switch (hairColor)
            {
                case "Super Blonde Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[0];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Blonde Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[1];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Brown Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[2];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Black Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[3];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Red Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[4];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Orange Hair":
                    femaleHairButton.GetComponent<Image>().sprite = femaleLongHair[5];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;
            }
        }

        else if (DropdownMenu.Instance.genVal == 1)
        {
            //check the string value of the button pressed
            switch (hairColor)
            {
                case "Super Blonde Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[0];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Blonde Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[1];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Brown Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[2];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Black Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[3];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Red Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[4];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;

                case "Orange Hair":
                    maleHairButton.GetComponent<Image>().sprite = maleHair[5];
                    MenuManager.Instance.hairVal = 0.ToString();
                    break;
            }
        }
        
        
    }

    //Change the eye color, taking the string input given when button pressed
    public void ChangeEyeColor(string eyeColor)
    {
        Vector2 finalPos = new Vector2(0, 1920);
        DropDownMenus[2].transform.localPosition = finalPos;

        //check which gender is checked
        if(DropdownMenu.Instance.genVal == 0)
        {
            switch (eyeColor)
            {
                case "Blue Eyes":
                    femaleEyeButton.GetComponent<Image>().sprite = femaleEyes[0];
                    MenuManager.Instance.eyeVal = 0.ToString();
                    break;

                case "Brown Eyes":
                    femaleEyeButton.GetComponent<Image>().sprite = femaleEyes[1];
                    MenuManager.Instance.eyeVal = 0.ToString();
                    break;

                case "Green Eyes":
                    femaleEyeButton.GetComponent<Image>().sprite = femaleEyes[2];
                    MenuManager.Instance.eyeVal = 0.ToString();
                    break;

                case "Hazel Eyes":
                    femaleEyeButton.GetComponent<Image>().sprite = femaleEyes[3];
                    MenuManager.Instance.eyeVal = 0.ToString();
                    break;
            }
        }
        
        else if(DropdownMenu.Instance.genVal == 1)
        {
            switch (eyeColor)
            {
                case "Blue Eyes":
                    maleEyeButton.GetComponent<Image>().sprite = maleEyes[0];
                    MenuManager.Instance.eyeVal = 0.ToString();
                    break;

                case "Brown Eyes":
                    maleEyeButton.GetComponent<Image>().sprite = maleEyes[1];
                    MenuManager.Instance.eyeVal = 1.ToString();
                    break;

                case "Green Eyes":
                    maleEyeButton.GetComponent<Image>().sprite = maleEyes[2];
                    MenuManager.Instance.eyeVal = 2.ToString();
                    break;

                case "Hazel Eyes":
                    maleEyeButton.GetComponent<Image>().sprite = maleEyes[3];
                    MenuManager.Instance.eyeVal = 3.ToString();
                    break;
            }
        }
        
    }

    //Change the skin color, taking the string input given when button pressed
    public void ChangeSkinColor(string skin)
    {
        Vector2 finalPos = new Vector2(0, 1920);
        DropDownMenus[0].transform.localPosition = finalPos;

        if(DropdownMenu.Instance.genVal == 0)
        {
            switch (skin)
            {
                case "Half Light":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[0];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[0];
                    MenuManager.Instance.skinVal = 0.ToString();
                    break;

                case "Light":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[1];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[1];
                    MenuManager.Instance.skinVal = 1.ToString();
                    break;

                case "Half Medium":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[2];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[2];
                    MenuManager.Instance.skinVal = 2.ToString();
                    break;

                case "Medium":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[3];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[3];
                    MenuManager.Instance.skinVal = 3.ToString();
                    break;

                case "Half Dark":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[4];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[4];
                    MenuManager.Instance.skinVal = 4.ToString();
                    break;

                case "Dark":
                    femaleSkinButton.GetComponent<Image>().sprite = femaleSkinColor[5];
                    femaleHandButton.GetComponent<Image>().sprite = femaleHandColor[5];
                    MenuManager.Instance.skinVal = 5.ToString();
                    break;
            }
        }

        else if(DropdownMenu.Instance.genVal == 1)
        {
            switch (skin)
            {
                case "Half Light":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[0];
                    MenuManager.Instance.skinVal = 0.ToString();
                    break;

                case "Light":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[1];
                    MenuManager.Instance.skinVal = 1.ToString();
                    break;

                case "Half Medium":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[2];
                    MenuManager.Instance.skinVal = 2.ToString();
                    break;

                case "Medium":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[3];
                    MenuManager.Instance.skinVal = 3.ToString();
                    break;

                case "Half Dark":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[4];
                    MenuManager.Instance.skinVal = 4.ToString();
                    break;

                case "Dark":
                    maleSkinButton.GetComponent<Image>().sprite = maleSkinColor[5];
                    MenuManager.Instance.skinVal = 5.ToString();
                    break;
            }
        }
        

    }

    //Change the outfit, taking the string input given when button pressed
    public void ChangeOutfit(string outfitSelection)
    {
       

        if(DropdownMenu.Instance.genVal == 0)
        {
            Vector2 finalPos = new Vector2(0, 1920);
            DropDownMenus[3].transform.localPosition = finalPos;

            switch (outfitSelection)
            {
                case "Outfit 1":
                    femaleOutfitButton.GetComponent<Image>().sprite = femaleOutfit[0];
                    MenuManager.Instance.outfitVal = 0.ToString();
                    break;

                case "Outfit 2":
                    femaleOutfitButton.GetComponent<Image>().sprite = femaleOutfit[1];
                    MenuManager.Instance.outfitVal = 1.ToString();
                    break;

                case "Outfit 3":
                    femaleOutfitButton.GetComponent<Image>().sprite = femaleOutfit[2];
                    MenuManager.Instance.outfitVal = 2.ToString();
                    break;

                case "Default":
                    femaleOutfitButton.GetComponent<Image>().sprite = femaleOutfit[3];
                    MenuManager.Instance.outfitVal = 3.ToString();
                    break;

            }
        }

        else if (DropdownMenu.Instance.genVal == 1)
        {
            Vector2 finalPos = new Vector2(0, 1920);
            DropDownMenus[5].transform.localPosition = finalPos;

            switch (outfitSelection)
            {
                case "Outfit 1":
                    maleOutfitButton.GetComponent<Image>().sprite = maleOutfit[0];
                    MenuManager.Instance.outfitVal = 0.ToString();
                    break;

                case "Outfit 2":
                    maleOutfitButton.GetComponent<Image>().sprite = maleOutfit[1];
                    MenuManager.Instance.outfitVal = 1.ToString();
                    break;

                case "Outfit 3":
                    maleOutfitButton.GetComponent<Image>().sprite = maleOutfit[2];
                    MenuManager.Instance.outfitVal = 2.ToString();
                    break;

                case "Default":
                    maleOutfitButton.GetComponent<Image>().sprite = maleOutfit[3];
                    MenuManager.Instance.outfitVal = 3.ToString();
                    break;

            }
        }

    }
}
