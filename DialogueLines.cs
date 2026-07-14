using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    //We made this script to set differnt dialogue lines with different dialogues. We could have made different dialogue lines(TMP) but what if we have 1000  lines?
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] timelineTextLines; //Array of strings(dialogue lines); This would be updated in NextDialogueLine method;
    int currentline = 0; //to keep track on what line it's playing currently;
    public void NextDialogueLine()  //public to make sure this method is accessible in Unity; 
    {
        currentline++;
        dialogueText.text = timelineTextLines[currentline];
    }
}

//Note for unity : add signal emmiters in between two dialogues in our timeline;

