using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace DataBank
{
    public class CharacterData
    {
        public string _id;
        public string _type;
        public int _gender;
        public string _hair;
        public string _skin;
        public string _eyes;
        public string _outfit;
        public string _dateCreated;

        /*hairVal = CharacterCustomization.Instance.hairString;
                skinVal = CharacterCustomization.Instance.skinString;
                eyeVal = CharacterCustomization.Instance.eyeString;
                outfitVal = CharacterCustomization.Instance.outfitString;*/

        public CharacterData(string id, string type, int gender, string hair, string skin, string eyes, string outfit)
        {
            _id = id;
            _type = type;
            _gender = gender;
            _hair = hair;
            _skin = skin;
            _eyes = eyes;
            _outfit = outfit;
            _dateCreated = "";
        }

        public CharacterData(string id, string type, int gender, string hair, string skin, string eyes, string outfit, string dateCreated)
        {
            _id = id;
            _type = type;
            _gender = gender;
            _hair = hair;
            _skin = skin;
            _eyes = eyes;
            _outfit = outfit;
            _dateCreated = dateCreated;
        }
    }
}

