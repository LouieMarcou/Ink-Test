using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InkTestScript : MonoBehaviour
{
	public TextAsset inkJson;
	private Story story;
	public TMP_Text text;
	public Button button;

	public List<GameObject> characters;
	private GameObject currentTalkingCharacter;

	private string dialogue;
	// Start is called before the first frame update
	void Start()
	{
		//Debug.Log(characters.Count);
		story = new Story(inkJson.text);
		//Debug.Log(story.currentTags.Count);
		dialogue = story.Continue();
		
		CheckTags();
		currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
		text.text = dialogue;
	}

	//IMPORTANT
	//First string in globalTags is a character in the scene
	//Second string in globalTags is whether if they start off activated

	//First string in current tag is the character who is talking
	//Second string in currentTags is character(s) to be removed
	//Third string in currentTags is character(s) to be added

	public void NextPieceOfDialogue()
	{
		if (story.canContinue)
		{
			//            Debug.Log(story.currentTags.Count);
			if (story.currentTags.Count > 1)
			{
				//Debug.Log(story.currentTags[1]);
				FindCharacterToRemove(story.currentTags[1]);
				if (story.currentTags.Count > 2)
				{
					//					Debug.Log(story.currentTags[2]);
					FindCharacterToAdd(story.currentTags[2]);
				}
			}
			dialogue = story.Continue();
			CheckTags();
			currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
			text.text = dialogue;
		}
	}

	private void CheckTags()
	{
		//Debug.Log(story.currentTags.Count);
		if (story.currentTags.Count > 0)
		{
			for (int i = 0; i < characters.Count; i++)
			{

				if (story.currentTags[0] == characters[i].GetComponent<CharacterTextBox>().Name)
				{
					//Debug.Log(characters[i].GetComponent<CharacterTextBox>().Name);

					currentTalkingCharacter = characters[i];
				}

			}

		}
	}

	private void FindCharacterToRemove(string name)
	{
		//Debug.Log(name);
		for (int i = 0; i < characters.Count; i++)
		{
			if (characters[i].GetComponent<CharacterTextBox>().Name == name)
			{
				//Debug.Log(characters[i].GetComponent<CharacterTextBox>().Name);
				characters[i].SetActive(false);
				return;
			}
		}
	}

	private void FindCharacterToAdd(string name)
	{
		//		Debug.Log(name);
		for (int i = 0; i < characters.Count; i++)
		{
			if (name.Contains(characters[i].GetComponent<CharacterTextBox>().Name))
			{
				//				Debug.Log(characters[i].GetComponent<CharacterTextBox>().Name);
				characters[i].SetActive(true);
			}
		}
	}
}
