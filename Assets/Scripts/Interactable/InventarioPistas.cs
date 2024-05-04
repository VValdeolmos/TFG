using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioPistas : MonoBehaviour
{
    public List<Pista> pistas;

    public static InventarioPistas instance;

    public void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public static void SetPista(Pista pista){
        if(instance == null)
        return;

        instance.pistas.Add(pista);
    }

    public static bool HasPista(Pista pista){
        if(instance == null)
        return false;

        return instance.pistas.Contains(pista);
    }
}

