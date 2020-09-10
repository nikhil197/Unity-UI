using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

[System.Serializable]
public class Tab2Slot
{
	[SerializeField]
	public Image SpriteSlot;

	[SerializeField]
	public Image LockSpriteSlot;

	[SerializeField]
	public ImageBlinker ImBlinker;
}

public class Tab2Controller : MonoBehaviour {

	[SerializeField]
	private ThemeMenuController ThemeController;

	[SerializeField]
	private List<Tab2Slot> Slots;

	void Awake()
	{
		List<Character> Characters = ThemeController.GetCharacters();
		for(int i = 0; i < Slots.Count; i++)
		{
			Slots[i].ImBlinker.images = new Sprite[Characters[i].Images.Length];
			for (int j = 0; j < Characters[i].Images.Length; j++)
				Slots[i].ImBlinker.images[j] = Characters[i].Images[j];
		}
	}

	void OnEnable()
	{
		List<Character> Characters = ThemeController.GetCharacters();
		int CharacterLevel = ThemeController.GetCharacterLevel();
		for (int i = 0; i < Slots.Count; i++)
		{
			Slots[i].ImBlinker.Reset();
			
			if(Characters[i].UnlockLevel > CharacterLevel)
			{
				Slots[i].LockSpriteSlot.gameObject.SetActive(true);
			}
			else
			{
				Slots[i].LockSpriteSlot.gameObject.SetActive(false);
			}
		}
	}
}
