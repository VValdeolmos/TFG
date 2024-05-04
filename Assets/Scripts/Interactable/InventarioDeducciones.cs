using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioDeducciones : MonoBehaviour
{
    public List<Deduccion> deducciones;

    public static InventarioDeducciones instance;

    public void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    

    public static bool HasDeduccion(Deduccion deduccion){
        if(instance == null)
        return false;

        return instance.deducciones.Contains(deduccion);
    }
}

