using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CollectablePistas : Interactable
{
    public Pista pista;
    [SerializeField] private NPCConversation myConv;

    public GameObject player;
    
    public bool terminado = false;
    public override void Interact(){
        if (isInteracting)
            return;
        isInteracting = true;
        ConversationManager.Instance.StartConversation(myConv);
        //player.GetComponent<ClickToMove>().estaEnDialogo = true;
        Debug.Log("Colecciona Pista: ");
        InventarioPistas.SetPista(pista);
        Destroy(gameObject);
    }

    //public void senalarTerminado(){
        //Debug.Log("Terminado: ");
        //player.GetComponent<ClickToMove>().estaEnDialogo = false;
    //}
}

