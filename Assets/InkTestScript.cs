using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkTestScript : MonoBehaviour
{
    public TextAsset inkJson;
    private Story story;
    public Text text;
    public Button button;

    public List<GameObject> characters;
    private GameObject currentTalkingCharacter;

    private string dialogue;
    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJson.text);
        dialogue = story.Continue();
        CheckTags();
        currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
        text.text = dialogue;
    }

    public void NextPieceOfDialogue()
    {
        if (story.canContinue)
        {
            //Debug.Log(story.globalTags.Count);
            dialogue = story.Continue();
            CheckTags();
            currentTalkingCharacter.GetComponent<CharacterTextBox>().MoveText();
            text.text = dialogue;
        }
    }

    private void CheckTags()
    {
        if (story.currentTags.Count > 0)
        {
            for(int i = 0; i < characters.Count; i++)
            {
                if (story.currentTags[0] == characters[i].name)
                {
                    currentTalkingCharacter = characters[i];
                }
            }

        }
    }
}
