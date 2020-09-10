using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ThemeMenuController : MonoBehaviour {

	[SerializeField]
	private MainMenuController MainController;

	[SerializeField]
	private PlaneTweener ThemeMenuTweener;

	[SerializeField]
	private List<Character> Characters;

	[SerializeField]
	private GameObject Tab1;
	
	[SerializeField]
	private GameObject Tab2;

	[SerializeField]
	private Sprite TabButtonSelectedSprite;
	
	[SerializeField]
	private Sprite TabButtonUnSelectedSprite;

	[SerializeField]
	private Button Tab1Button;
	
	[SerializeField]
	private Button Tab2Button;

	// Index for the character to be shown in the theme tab1
	int CurrentActiveIndex;

	// Index for the character selected
	private int SelectedCharacterIndex;

	void Awake()
	{
		if (MainController == null)
			Debug.LogError("Main Menu Controller not set for the theme menu");
		if (Characters.Count == 0)
			Debug.LogError("No Characters specified");
		if (ThemeMenuTweener == null)
			Debug.LogError("Theme Menu Tweener must be set in the inspector");

		CurrentActiveIndex = 0;
		SelectedCharacterIndex = 0;
	}

	void OnEnable()
	{
		CurrentActiveIndex = SelectedCharacterIndex;
		Characters[SelectedCharacterIndex].IsSelected = true;
		OnSelectTab1();
	}

	public void OnChangeSelected()
	{
		Characters[SelectedCharacterIndex].IsSelected = false;
		SelectedCharacterIndex = CurrentActiveIndex;
	}

	public void OnSelectTab1()
	{
		// Set the correct sprite
		Tab1Button.image.sprite = TabButtonSelectedSprite;
		Tab2Button.image.sprite = TabButtonUnSelectedSprite;

		// Activate the tab
		Tab1.SetActive(true);
		Tab2.SetActive(false);
	}

	public void OnSelectTab2()
	{
		// Set the correct sprite
		Tab1Button.image.sprite = TabButtonUnSelectedSprite;
		Tab2Button.image.sprite = TabButtonSelectedSprite;

		// Activate the tab
		Tab1.SetActive(false);
		Tab2.SetActive(true);
	}

	public void OnThemeMenuClose()
	{
		ThemeMenuTweener.Close();
	}

	public void NextCharacter()
	{
		CurrentActiveIndex = (CurrentActiveIndex + 1) % Characters.Count;
	}

	public void PrevCharacter()
	{
		CurrentActiveIndex = (Characters.Count + CurrentActiveIndex - 1) % Characters.Count; 
	}

	public List<Character> GetCharacters()
	{
		return Characters;
	}

	public Character GetCurrentActiveCharacter()
	{
		return Characters[CurrentActiveIndex];
	}

	public int GetCharacterLevel()
	{
		return MainController.CharacterLevel;
	}

}
