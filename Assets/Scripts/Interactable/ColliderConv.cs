using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ColliderConv : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;
    
    public void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player"))
        {
        ConversationManager.Instance.StartConversation(myConv);
        Destroy(gameObject);
        }
    }
}
