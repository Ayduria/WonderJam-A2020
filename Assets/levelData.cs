using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelData : MonoBehaviour
{
             private void Awake() {
                PlayerPrefs.SetString("DefaultsSet","True");
    
                //Player Specific Values
                PlayerPrefs.SetString("Player:Name","Jerry");
                PlayerPrefs.SetInt("Player:Coins",0);
                PlayerPrefs.SetInt("Player:ProgressLevel",0);
                PlayerPrefs.SetInt("Player:EquippedGunId",0);
                PlayerPrefs.SetInt("Player:EquippedHelmetId",0);
    
                //Shop Values (
                PlayerPrefs.SetString("Shop:Purchased:Gun0","True");
                PlayerPrefs.SetString("Shop:Purchased:Gun1","False");
                PlayerPrefs.SetString("Shop:Purchased:Gun2","False");
    
                PlayerPrefs.SetString("Shop:Purchased:Helmet0","True");
                PlayerPrefs.SetString("Shop:Purchased:Helmet1","False");
                PlayerPrefs.SetString("Shop:Purchased:Helmet2","False");    
             }
}



