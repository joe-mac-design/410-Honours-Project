using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu_UI_Script : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent< UIDocument > ().rootVisualElement;

        Button ButtonPlay = root.Q<Button>("ButtonPlay");
        Button ButtonOptions = root.Q<Button>("ButtonOptions");
        Button ButtonQuit = root.Q<Button>("ButtonQuit");

        ButtonPlay.clicked += () => SceneManager.LoadScene("");
        ButtonOptions.clicked += () => 
        ButtonQuit.clicked += () => Application.Quit();
    }

}
