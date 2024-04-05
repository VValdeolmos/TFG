using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject interactionPanel;
    public TMP_Text interactionText;

    TextInteractable textInteractable;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public static void SetText(TextInteractable interactable){
        if(instance == null){
            return;
        }
        if(interactable.conditionalItem != null){
            Debug.Log("Tenemos el item condicional");
            if(Inventory.HasItem(interactable.conditionalItem)){
                Debug.Log("Tenemos el item");
                instance.interactionText.text = interactable.conditionalText;
            }
            else{
                Debug.Log("No tenemos el item");
                instance.interactionText.text = interactable.text;
            }
        }
        else{
            Debug.Log("Jugador no tiene item condicional");
            instance.interactionText.text = interactable.text;
        }
        instance.interactionPanel.SetActive(true);
        instance.textInteractable = interactable;
        

    }

    public static void DisableInteraction(){
        if(instance == null){
            return;
        }
        instance.interactionPanel.SetActive(false);
        if(instance.textInteractable != null){
            instance.textInteractable.isInteracting = false;
        }

    }

}
