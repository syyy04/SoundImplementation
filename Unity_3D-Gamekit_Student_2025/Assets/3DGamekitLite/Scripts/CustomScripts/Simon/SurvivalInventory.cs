using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Scriptables/Survival/Inventory")]
public class SurvivalInventory : ScriptableObject
{
     public int waterBottles;

     private void OnEnable()
     {
          waterBottles = 0;
     }

     public void WaterBottlesGet()
     {
          waterBottles += Random.Range(0, 3);
     }
}
