using System.Collections.Generic;
using UnityEngine;
using DataBank;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorTest : MonoBehaviour
{
	public Text txt;

	private void Start()
	{
		resetColors();
	}
	public void selectColor()
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
			myList.Add(entity);
		}

		int count = myList.Count;

		string btn = EventSystem.current.currentSelectedGameObject.name;

		if (count == 0)
		{
			addColor("1", "Family", btn);
			txt.text = "Select a Color for Friends:";
		} 
		else if (count == 1)
		{
			addColor("2", "Friends", btn);
			txt.text = "Select a Color for Strangers:";
		}
		else if (count == 2)
		{
			addColor("3", "Strangers", btn);
			SceneManager.LoadScene("UploadPicOrNotSection");
		}
		else
		{
			resetColors();
		}
		mColorDB.close();
	}

	void addColor(string id, string group, string color)
	{
		ColorDB mColorDB = new ColorDB();
		mColorDB.addData(new ColorData(id, group, color));
		mColorDB.close();
	}

	public void readDatabase()
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
	}

	public void resetColors()
	{
		ColorDB mColorDB = new ColorDB();
		mColorDB.deleteAllData();
		txt.text = "Select a Color for Family:";
	}

	public void NextScene()
	{
		SceneManager.LoadScene("UploadPicOrNotSection");
	}
}