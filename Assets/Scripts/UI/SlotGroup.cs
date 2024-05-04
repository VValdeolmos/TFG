using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGroup : MonoBehaviour
{
    public List<Slot> tabButtons;
    public Color normalColor;
    public Color highlatedColor;
    public Color selectedColor;
    public Slot selectedTab;
    public Pista actualPista;
    public Pista anteriorPista;

    public InventarioDeducciones inventario;

    public void Subscribe(Slot button){
        if(tabButtons == null){
            tabButtons = new List<Slot>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(Slot button){
        ResetTabs();
        if(selectedTab == null || button != selectedTab){
        button.tabImage.color = highlatedColor;
        }
    }

    public void OnTabExit(Slot button){
        ResetTabs();
    }

    public void OnTabSelected(Slot button){
        selectedTab = button;
        ResetTabs();
        button.tabImage.color = selectedColor;
        if(actualPista == null){
            actualPista = selectedTab.pista;
        }
        else{
            if(actualPista != selectedTab.pista){
                anteriorPista = actualPista;
                actualPista = selectedTab.pista;
                for(int i = 0; i < inventario.deducciones.Count; i++){
                    if(inventario.deducciones[i].pista1 && actualPista || inventario.deducciones[i].pista2 && actualPista){
                        if(inventario.deducciones[i].pista1 && anteriorPista || inventario.deducciones[i].pista2 && anteriorPista)
                        inventario.deducciones[i].enabled = true;
                    }
                }
            }
        }
        
        
    }

    public void ResetTabs(){
        foreach(Slot button in tabButtons){
            if(selectedTab!=null && button == selectedTab){ continue; }
            button.tabImage.color = normalColor;
        }
    }
}