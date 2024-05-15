using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DecisionFinal : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;

    public GameObject canva;

    public GameObject decisionF;

    void Update(){
        if (Input.GetKeyDown(KeyCode.E) && decisionF.activeInHierarchy){
        canva.SetActive(false);
        Time.timeScale = 1;        
        ConversationManager.Instance.StartConversation(myConv);
        }
    }

}
