using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotGroup : MonoBehaviour
{
    public List<Slot> tabButtons;
    public Color normalColor;
    public Color highlatedColor;
    public Color selectedColor;
    public Slot selectedTab;
    public Pista actualPista;
    public Pista anteriorPista;
    public List<GameObject> deduccUI;

    public InventarioDeducciones inventario;

    public TMP_Text pistaTexto1;
    public TMP_Text pistaTexto2;

    public TMP_Text deduccionNoti;



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
            pistaTexto1.SetText(actualPista.pistaName); 
            deduccionNoti.SetText("-");
            pistaTexto2.SetText("-");
        }
        else{
            if(actualPista != selectedTab.pista){
                anteriorPista = actualPista;
                actualPista = selectedTab.pista;
                pistaTexto2.SetText(actualPista.pistaName);
                for(int i = 0; i < inventario.deducciones.Count; i++){
                    Debug.Log(inventario.deducciones[i].pista1.pistaName);
                    Debug.Log(inventario.deducciones[i].pista2.pistaName);
                    if(inventario.deducciones[i].pista1 == actualPista || inventario.deducciones[i].pista2 == actualPista)
                        if(inventario.deducciones[i].pista1 == anteriorPista || inventario.deducciones[i].pista2 == anteriorPista){
                        inventario.deducciones[i].enabled = true;
                        deduccUI[i].SetActive(true);
                        Debug.Log("PistaActual: " + actualPista.pistaName);
                        Debug.Log("PistaAnterior: " + anteriorPista.pistaName);
                        Debug.Log("Activo deduccion: " + i);
                        deduccionNoti.SetText("Deducción exitosa");
                        actualPista = null;
                        anteriorPista = null;

                         for(int j = 0; j < inventario.deducciones.Count; j++){
                            if(inventario.deducciones[j].enabled == true){
                               if(j == inventario.deducciones.Count-1){
                                Debug.Log("Activando deduccion final:" + j);
                                deduccUI[4].SetActive(true);
                                deduccionNoti.SetText("Deducción final alcanzada");
                                break;
                                } 
                            }
                        }
                        break;
                        }
                        if(i == 3){
                            deduccionNoti.SetText("Deducción fallida");
                            actualPista = null;
                            anteriorPista = null;
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