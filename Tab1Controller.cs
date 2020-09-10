using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Tab1Controller : MonoBehaviour {

	// Theme Menu Controller
	[SerializeField]
	private ThemeMenuController ThemeController;

	[SerializeField]
	private Text CharacterNameField;

	// Button to select the displayed character
	[SerializeField]
	private Button SelectButton;

	// Shows the 'Selected' or 'Level X' Text
	[SerializeField]
	private Text SelectedOrReqLevelText;

	// Images on left and right side of 'Selected Text'
	[SerializeField]
	private Image YesLeftImage;
	
	[SerializeField]
	private Image YesRightImage;

	[SerializeField]
	private ImageBlinker ImBlinker;

	// Character shown in the menu
	private Character CurrentActiveCharacter;

	void OnEnable()
	{
		OnCharacterUpdate();
	}

	public void OnLeftButtonClick()
	{
		ThemeController.PrevCharacter();
		OnCharacterUpdate();
	}

	public void OnRightButtonClick()
	{
		ThemeController.NextCharacter();
		OnCharacterUpdate();
	}

	public void OnSelectButtonClick()
	{
		ThemeController.OnChangeSelected();
		CurrentActiveCharacter.IsSelected = true;
		SelectButton.gameObject.SetActive(false);
		SelectedOrReqLevelText.gameObject.SetActive(true);
		SelectedOrReqLevelText.text = "Selected";
		YesLeftImage.gameObject.SetActive(true);
		YesRightImage.gameObject.SetActive(true);
	}

	private void OnCharacterUpdate()
	{
		CurrentActiveCharacter = ThemeController.GetCurrentActiveCharacter();
		CharacterNameField.text = CurrentActiveCharacter.Name;

		ImBlinker.Reset();
		// To make sure the blinker has the required number of image slots
		if(ImBlinker.images.Length != CurrentActiveCharacter.Images.Length)
		{
			ImBlinker.images = null;
			ImBlinker.images = new Sprite[CurrentActiveCharacter.Images.Length];
		}
		
		// Set the new sprites in the blinker
		for(int i = 0; i < CurrentActiveCharacter.Images.Length; i++)
		{
			ImBlinker.images[i] = CurrentActiveCharacter.Images[i];
		}

		// If the character is not unlocked
		if (CurrentActiveCharacter.UnlockLevel > ThemeController.GetCharacterLevel())
		{
			SelectButton.gameObject.SetActive(false);
			SelectedOrReqLevelText.gameObject.SetActive(true);
			SelectedOrReqLevelText.text = "Level " + CurrentActiveCharacter.UnlockLevel.ToString();
			YesLeftImage.gameObject.SetActive(false);
			YesRightImage.gameObject.SetActive(false);
		}
		else
		{
			// If the character is selected
			if (CurrentActiveCharacter.IsSelected)
			{
				SelectButton.gameObject.SetActive(false);
				SelectedOrReqLevelText.gameObject.SetActive(true);
				SelectedOrReqLevelText.text = "Selected";
				YesLeftImage.gameObject.SetActive(true);
				YesRightImage.gameObject.SetActive(true);
			}
			else
			{
				SelectButton.gameObject.SetActive(true);
				SelectedOrReqLevelText.gameObject.SetActive(false);
				YesLeftImage.gameObject.SetActive(false);
				YesRightImage.gameObject.SetActive(false);
			}
		}
	}
}
