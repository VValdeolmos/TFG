using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public Pista pista;
    public SlotGroup tabGroup;

    public Image tabImage;
    public TMP_Text pistaTexto;


    public void OnPointerClick(PointerEventData eventData){
        tabGroup.OnTabSelected(this);
    }
    public void OnPointerEnter(PointerEventData eventData){
        tabGroup.OnTabEnter(this);
    }
    public void OnPointerExit(PointerEventData eventData){
        tabGroup.OnTabExit(this);
    }

    public void addPista(Pista newPista){
        pista = newPista;
        pistaTexto.SetText(pista.pistaName); 
    }

    public void clearSlot (){
        //pista = null;
        //pistaTexto = null;
    }
}
