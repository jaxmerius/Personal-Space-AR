using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownMenu : MonoBehaviour
{
    public static DropdownMenu Instance;

    public TextMeshProUGUI genderPicker;

    public GameObject female;
    public GameObject male;

    public int genVal = 0;
    public string typeVal ;

    private void Start()
    {
        Instance = this;
        typeVal = "close";
    }

    //function to handle input from the gender picker drop down menu
    public void HandleInputData(int value)
    {
        //check drop down menu value
        if(value == 0)
        {
            Debug.Log("Female");

            //Set genVal to appropriate number
            genVal = value;

            //Set appropriate character to active
            male.SetActive(false);
            female.SetActive(true);
        }
        else if(value == 1)
        {
            Debug.Log("Male");

            //Set genVal to appropriate number
            genVal = value;

            //Set appropriate character to active
            female.SetActive(false);
            male.SetActive(true);
        }
        else
        {
            Debug.Log("Please pick an identifier type 1");
        }
        
    }

    public void TypeHandler (int value)
    {
        //check drop down menu value
        if (value == 0)
        {
            typeVal = "close";
            Debug.Log(typeVal);
        }
        else if (value == 1)
        {
            typeVal = "near";
            Debug.Log(typeVal);
        }
        else if (value == 2)
        {
            typeVal = "far";
            Debug.Log(typeVal);
        }
        else
        {
            Debug.Log("Please pick an identifier type 2");
        }
    }

}
