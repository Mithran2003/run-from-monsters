using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Controller : MonoBehaviour
{
    public static int  selected_player;
    public void PlayGame ( int select_player) 
    {
        Debug.Log("Buttion pressed ");
        Debug.Log((selected_player+1) +"selected");
        Game_Manager.instance.CharName=selected_player;
        Debug.Log(Game_Manager.instance.CharName+"is the character name");
        SceneManager.LoadScene("Gameplay");
        
    }
    
    public void SelectCharacter1 () 
    {
         selected_player = 0;
        Debug.Log("Player one selected");
        PlayGame(selected_player);
       
        
    }
    public void SelectCharacter2 () 
    {
        selected_player = 1;
        Debug.Log("Player two selected");
        PlayGame(selected_player);
       
        
    }
}   
