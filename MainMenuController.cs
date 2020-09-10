using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	public InputField CharacterLevelField;

	[SerializeField]
	private GameObject ThemeMenu;
	
	public int CharacterLevel { get; internal set; }

	void Awake()
	{
		CharacterLevel = 0;
		CharacterLevelField.text = CharacterLevel.ToString();
	}

	public void OnClickThemeMenu()
	{
		ThemeMenu.SetActive(true);
	}

	public void OnCharacterLevelChange()
	{
		int level;
		bool result = Int32.TryParse(CharacterLevelField.text, out level);
		if(!result)
		{
			Debug.LogError("Character Level not set correctly");
		}
		else
		{
			CharacterLevel = level;
		}
	}
}
