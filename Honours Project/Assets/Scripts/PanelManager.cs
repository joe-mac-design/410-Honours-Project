using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class PanelManager : MonoBehaviour
{
    
    public UIDocument Document;
    private Button _playButton;
    private Button _optionsButton;
    private Button _quitButton; 

    private void Awake()
    {
        Document = GetComponent<UIDocument>();

        _playButton = Document.rootVisualElement.Q<Button>("Play_btn");
        _playButton.clicked += PlayButtonClicked;

        _optionsButton = Document.rootVisualElement.Q<Button>("Options_btn");
        _optionsButton.clicked += OptionsButtonClicked;

        _quitButton = Document.rootVisualElement.Q<Button>("Quit_btn");
        _quitButton.clicked += QuitButtonClicked;
        Debug.Log("Quit");

    }
    private void OptionsButtonClicked()
    {
        // switch between visual trees
        Document.rootVisualElement.Q<VisualElement>("OptionsMenuContainer").style.display = DisplayStyle.Flex;
        Document.rootVisualElement.Q<VisualElement>("MainMenuContainer").style.display = DisplayStyle.None;
    }
    private void QuitButtonClicked()
    {
        Application.Quit();
    }

    private void PlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
