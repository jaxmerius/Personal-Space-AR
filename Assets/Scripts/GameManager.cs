using System.Collections;
using System.Collections.Generic;
using DataBank;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera firstPersonCamera;
    public PersonController personController;
    public GameObject center;
    public Renderer closeCircle;
    public Renderer nearCircle;
    public Renderer farCircle;
    public GameObject person;
    public Text mainText;
    public Button action;
    public GameObject verificationScreen;
    public Text panelText;
    public Text panelButtonText;
    //public GameObject test;

    private Vector3 targetPostition;


    private List<Material> mats;

    private string goalDist;
    private bool correct = false;

    private string closeColor;
    private string nearColor;
    private string farColor;

    //Hannah
    public GameObject character;


    private bool planeSelected = false;

    void Start()
    {
        QuitOnConnectionErrors();
        center.SetActive(false);
        character.SetActive(false);
        //person.SetActive(false);
        SetUpPerson();
        mats = Resources.LoadAll<Material>("ColorMaterials/").ToList();
        //goalDist = "close";
        
    }

    void Update()
    {
        // The session status must be Tracking in order to access the Frame.
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        
        
        if (planeSelected)
        {
            center.transform.position = new Vector3(firstPersonCamera.transform.position.x, person.transform.position.y, firstPersonCamera.transform.position.z);
            targetPostition = new Vector3(firstPersonCamera.transform.position.x,
                                       character.transform.position.y,
                                       firstPersonCamera.transform.position.z);
            character.transform.LookAt(targetPostition);
            Debug.Log(targetPostition.ToString());
            //test.transform.position = person.transform.position;
            CalculateDistance();
        }
        else
        {
            ProcessTouches();
        }
        
    }

    void SetUpPerson()
    {
        
            CharacterDB mCharacterDB = new CharacterDB();
            //CharacterData characterData;
            System.Data.IDataReader reader = mCharacterDB.getAllData();
            List<CharacterData> myList = new List<CharacterData>();
            while (reader.Read())
            {
                CharacterData entity = new CharacterData(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

                Debug.Log("Character type is " + reader[1].ToString());

                myList.Add(entity);
            }
            goalDist = myList[0]._type;

            Debug.Log("Character Data: " + myList[0]._type + myList[0]._gender.ToString() + myList[0]._hair + myList[0]._skin + myList[0]._eyes + myList[0]._outfit);

        try
        {
            //check if female or male character was chosen
            if (myList[0]._gender.ToString() == 0.ToString())
            {
                //Activate female character
                CharacterCustomization.Instance.female.SetActive(true);
                Debug.Log("Female character was chosen: " + myList[0]._gender);

                //Get characters sprite components
                SpriteRenderer[] charactersAttributes = CharacterCustomization.Instance.female.GetComponentsInChildren<SpriteRenderer>();

                //Add user's style choices
                charactersAttributes[0].sprite = CharacterCustomization.Instance.femaleOutfit[int.Parse(myList[0]._outfit)];
                charactersAttributes[2].sprite = CharacterCustomization.Instance.femaleLongHair[int.Parse(myList[0]._hair)];
                charactersAttributes[3].sprite = CharacterCustomization.Instance.femaleEyes[int.Parse(myList[0]._eyes)];
                charactersAttributes[4].sprite = CharacterCustomization.Instance.femaleSkinColor[int.Parse(myList[0]._skin)];
                charactersAttributes[5].sprite = CharacterCustomization.Instance.femaleHandColor[int.Parse(myList[0]._skin)];

                Debug.Log("Hair Value: " + myList[0]._hair);
            }
            else if(myList[0]._gender.ToString() == 1.ToString())
            {
                //Activate male character
                CharacterCustomization.Instance.male.SetActive(true);
                Debug.Log("Male character was chosen: " + myList[0]._gender);

                //Get characters SpriteRenderer components
                SpriteRenderer[] charactersAttributes = CharacterCustomization.Instance.male.GetComponentsInChildren<SpriteRenderer>();

                //Add user's style choices
                charactersAttributes[0].sprite = CharacterCustomization.Instance.maleOutfit[int.Parse(myList[0]._outfit)];
                charactersAttributes[2].sprite = CharacterCustomization.Instance.maleHair[int.Parse(myList[0]._hair)];
                charactersAttributes[3].sprite = CharacterCustomization.Instance.maleEyes[int.Parse(myList[0]._eyes)];
                charactersAttributes[4].sprite = CharacterCustomization.Instance.maleSkinColor[int.Parse(myList[0]._skin)];
            }

            //Sprite characterModel = CharacterCustomization.Instance.female.GetComponentInChildren<Sprite>();
        }
        catch
        {
            Debug.Log("CHARACTER NOT LOADED");
            mainText.text = "CHARACTER NOT LOADED";
        }

        //person.SetActive(false);
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            // This covers a variety of errors.  See reference for details
            // https://developers.google.com/ar/reference/unity/namespace/GoogleARCore
            StartCoroutine(CodelabUtils.ToastAndExit("ARCore encountered a problem connecting. Please restart the app.", 5));
        }
        
    }

    void ProcessTouches()
    {
        Touch touch;
        if (Input.touchCount != 1 ||
            (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinBounds | TrackableHitFlags.PlaneWithinPolygon;
        Debug.Log(touch.position.x + " + " + touch.position.y);

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            //Debug.Log("are we here??????");
            SetSelectedPlane(hit.Trackable as DetectedPlane);
        }
    }

    void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        Debug.Log("Selected plane centered at " + selectedPlane.CenterPose.position);
        character.SetActive(true);
        //person.SetActive(true);
        //personController.SetSelectedPlane(selectedPlane);
        person.transform.position = new Vector3(selectedPlane.CenterPose.position.x, selectedPlane.CenterPose.position.y, selectedPlane.CenterPose.position.z);
        character.transform.position = new Vector3(selectedPlane.CenterPose.position.x, selectedPlane.CenterPose.position.y, selectedPlane.CenterPose.position.z);
        
        
        CenterSetUp();
        planeSelected = true;
    }

    void CenterSetUp ()
    {
        center.SetActive(true);
        SetColors();
    }

    public void SetColors()
    {
        ColorDB mColorDB = new ColorDB();
        System.Data.IDataReader reader = mColorDB.getAllData();

        List<ColorData> myList = new List<ColorData>();
        while (reader.Read())
        {
            ColorData entity = new ColorData(reader[0].ToString(),
                                    reader[1].ToString(),
                                    reader[2].ToString(),
                                    reader[3].ToString());

            Debug.Log("id: " + entity._id + "\tcolor: " + entity._color + "\tgroup: " + entity._type);
            myList.Add(entity);
        }
        int i = 0;
        foreach (ColorData entity in myList)
        {

            if (i == 0)
            {
                closeColor = myList[i]._color;
                Debug.Log("Close color is " + myList[i]._color.ToString());
                closeCircle.material = mats[MatNum(myList[i]._color.ToString())];
            }
            else if (i == 1)
            {
                nearColor = myList[i]._color;
                Debug.Log("Near color is " + myList[i]._color.ToString());
                nearCircle.material = mats[MatNum(myList[i]._color.ToString())];
            }
            else
            {
                farColor = myList[i]._color;
                Debug.Log("Far color is " + myList[i]._color.ToString());
                farCircle.material = mats[MatNum(myList[i]._color.ToString())];
            }
            i++;
        }
    }

    int MatNum (string s)
    {
        int m = 10;
        if (s == "Blue")
        {
            m = 0;
        }
        else if (s == "Brown")
        {
            m = 1;
        }
        else if (s == "Cyan")
        {
            m = 2;
        }
        else if (s == "Green")
        {
            m = 3;
        }
        else if (s == "Orange")
        {
            m = 4;
        }
        else if (s == "Pink")
        {
            m = 5;
        }
        else if (s == "Purple")
        {
            m = 6;
        }
        else if (s == "Red")
        {
            m = 7;
        }
        else if (s == "Yellow")
        {
            m = 8;
        }
        else
        {
            Debug.Log("Whoops!");
        }
        return m;
    }

    void CalculateDistance()
    {
        float dist = Vector3.Distance(person.transform.position, center.transform.position); 
        
        if (dist < 0.5)
        {
            mainText.text = "Close";
            action.interactable = true;
        }
        else if (dist > 0.5 && dist < 1.0)
        {
            mainText.text = "Near";
            action.interactable = true;
        }
        else if (dist > 1.0 && dist < 1.5)
        {
            mainText.text = "Far";
            action.interactable = true;
        }
        else
        {
            mainText.text = "Very Far";
            action.interactable = false;
        }
    }

    public void Action()
    {
        float dist = Vector3.Distance(person.transform.position, center.transform.position); 
        verificationScreen.SetActive(true);
        if (goalDist == "close")
        {
            if (dist < 0.5)
            {
                panelText.text = "Nice!";
                panelButtonText.text = "Continue";
                correct = true;
            }
            else if (dist > 0.5 && dist < 1.0)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
            else if (dist > 1.0 && dist < 1.5)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
        }
        else if (goalDist == "near")
        {
            if (dist < 0.5)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
            else if (dist > 0.5 && dist < 1.0)
            {
                panelText.text = "Nice!";
                panelButtonText.text = "Continue";
                correct = true;
            }
            else if (dist > 1.0 && dist < 1.5)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
        }
        else
        {
            if (dist < 0.5)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
            else if (dist > 0.5 && dist < 1.0)
            {
                panelText.text = "Not quite";
                panelButtonText.text = "Try Again";
            }
            else if (dist > 1.0 && dist < 1.5)
            {
                panelText.text = "Nice!";
                panelButtonText.text = "Continue";
                correct = true;
            }
        }
    }

    public void PanelButton ()
    {
        if (correct)
        {
            SceneManager.LoadScene("ColorPicker");
        }
        else
        {
            verificationScreen.SetActive(false);
        }
    }
}
