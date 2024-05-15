using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDeduccion", menuName = "Deduccion")]
public class Deduccion : ScriptableObject
{
    public string DeducName;
    public Pista pista1;
    public Pista pista2;
    public string description;
    public bool enabled = false;
}
