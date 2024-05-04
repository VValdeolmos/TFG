using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioPistasUI : MonoBehaviour
{
    public Transform pistasParent;
    InventarioPistas inventario;

    Slot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventario = InventarioPistas.instance;
        slots = pistasParent.GetComponentsInChildren<Slot>();
        UpdateUI();

        
        
        Debug.Log(slots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    void UpdateUI(){
        for(int i = 0; i<slots.Length; i++){
            if(i < inventario.pistas.Count){
                   
                slots[i].addPista(inventario.pistas[i]);
            }
            else{
                slots[i].clearSlot();
                
            }
        }
        
    }
}
