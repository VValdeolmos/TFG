using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CollectablePistas : Interactable
{
    public Pista pista;
    [SerializeField] private NPCConversation myConv;

    //public GameObject player;

    public GameObject pistaNoti;

    //public GameObject panelLayer;
    
    public bool terminado = false;
    public override void Interact(){
        if (isInteracting)
            return;
        isInteracting = true;
        ConversationManager.Instance.StartConversation(myConv);
        //player.GetComponent<ClickToMove>().estaEnDialogo = true;
        Debug.Log("Colecciona Pista: ");
        InventarioPistas.SetPista(pista);
        pistaNoti.SetActive(true);
        StartCoroutine("RutinaNoti");
        


        //Destroy(gameObject);
    }

    IEnumerator RutinaNoti(){
        yield return new WaitForSeconds(5);
        pistaNoti.SetActive(false);
    }

    //public void senalarTerminado(){
        //Debug.Log("Terminado: ");
        //player.GetComponent<ClickToMove>().estaEnDialogo = false;
    //}
}

