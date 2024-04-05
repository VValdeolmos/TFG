using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;
    bool isPlayerInRange = false;

    private void Update(){
        if(isPlayerInRange){
            Debug.Log("Falta la F");
            if(Input.GetKeyDown(KeyCode.F)){
                ConversationManager.Instance.StartConversation(myConv);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Se puede iniciar el diálogo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No se puede iniciar el diálogo");
        }
    }
}
