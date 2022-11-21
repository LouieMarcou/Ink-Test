using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InkTestScript : MonoBehaviour
{
	public TextAsset inkJson;
	private Story story;
	public TMP_Text text;
	public Button button;

	//add all characters in the scene to this list
	public List<GameObject> characters;
	private GameObject currentTalkingCharacter;

	private string dialogue;

	public string NextSceneToTranistionTo;
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("scene starting");
		story = new Story(inkJson.text);
		Debug.Log(story);
		dialogue = story.Continue();
		
		CheckTags();
		if(story.currentTags[0] != "context")
			//currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
		text.text = dialogue;
	}

	//IMPORTANT
	//First string in current tag is the character who is talking
	//Second string in currentTags is character(s) to be removed
	//Third string in currentTags is character(s) to be added
	//Turn the gameobject of the of all characters off.
	//Tags with context describe whats happening in the scene will change code to not display them later

	public void NextPieceOfDialogue()
	{
		if (story.canContinue)
		{
			if (story.currentTags.Count > 1)
			{
				FindCharacterToRemove(story.currentTags[1]);
				if (story.currentTags.Count > 2)
				{
					FindCharacterToAdd(story.currentTags[2]);
				}
			}
			dialogue = story.Continue();
			CheckTags();
			if (story.currentTags[0] != "context")
				//currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
			text.text = dialogue;
		}
		else
        {
			if(NextSceneToTranistionTo != null)
				SceneManager.LoadScene(NextSceneToTranistionTo);
		}
	}

	private void CheckTags()
	{
		if (story.currentTags.Count > 0)
		{
			for (int i = 0; i < characters.Count; i++)
			{
				if(story.currentTags[0] == "context")
                {
					return;
                }
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
			if (name.Contains(characters[i].GetComponent<CharacterTextBox>().Name))
			{
				//Debug.Log(characters[i].GetComponent<CharacterTextBox>().Name);
				characters[i].SetActive(false);
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
