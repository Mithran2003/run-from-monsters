using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    [SerializeField]
    private GameObject[] characters;
    private int _charName;
    public int  CharName
    {
        get { return _charName;}
        set {_charName = value;}
    }    
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
     private void OnEnable() 
    {
       SceneManager.sceneLoaded += OnLevelFinishedLoading; 
    } 
    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; 
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            Instantiate(characters[CharName]);
        }
    }    
}

