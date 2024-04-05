using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TextInteractable : Interactable
{
    public string text;
    public string conditionalText;
    public Item conditionalItem;
    [SerializeField] private NPCConversation myConv;
    
    

    public override void Interact(){
        if (isInteracting)
            return;

        isInteracting = true;;
        ConversationManager.Instance.StartConversation(myConv);
    }
}
