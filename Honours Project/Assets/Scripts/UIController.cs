using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Play Menu
    public Button playButton;
    public VisualElement StaticMap;
    public Button StaticNAButton;
    public VisualElement ActiveMap;
    public Button ActiveNAButton;

    // Options Menu
    public Button optionsButton;

    // Quit Menu
    public Button quitButton;
    public Button quitConfirmButton;
    public Button quitNegativeButton;

    // Profile Menu
    public Button profileButton;

    // Visual Elements
    public VisualElement playMenu;
    public VisualElement optionsMenu;
    public VisualElement quitMenu;
    public VisualElement profileMenu;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        optionsButton = root.Q<Button>("OptionsButton");
        
        quitButton = root.Q<Button>("QuitButton");
        quitConfirmButton = root.Q<Button>("ConfirmBtn");
        quitNegativeButton = root.Q<Button>("NegativeBtn");
        
        profileButton = root.Q<Button>("ProfileButton");

        optionsMenu = root.Q<VisualElement>("OptionsMenuContainer");
        quitMenu = root.Q<VisualElement>("QuitMenuContainer");
        playMenu = root.Q<VisualElement>("PlayMenuContainer");
        profileMenu = root.Q<VisualElement>("ProfileMenuContainer");

        StaticMap = root.Q<VisualElement>("StaticMapContainer");
        StaticNAButton = root.Q<Button>("StaticNA");
        ActiveMap = root.Q<VisualElement>("ActiveMapContainer");
        ActiveNAButton = root.Q<Button>("ActiveNA");

        optionsButton.clicked += OptionsButtonActive;
        quitButton.clicked += QuitButtonActive;
        playButton.clicked += PlayButtonActive;
        profileButton.clicked += ProfileButtonActive;

        quitConfirmButton.clicked += QuitConfirmActive;
        quitNegativeButton.clicked += QuitNegativeActive;

        StaticNAButton.clicked += ActiveMapActive;
        ActiveNAButton.clicked += StaticMapActive;
    }

    void PlayButtonActive()
    {
        playMenu.style.display = DisplayStyle.Flex;
        quitMenu.style.display = DisplayStyle.None;
        optionsMenu.style.display = DisplayStyle.None;
        profileMenu.style.display = DisplayStyle.None;
    }

    void OptionsButtonActive()
    {
        optionsMenu.style.display = DisplayStyle.Flex;
        quitMenu.style.display = DisplayStyle.None;
    }

    void QuitButtonActive()
    {
        quitMenu.style.display = DisplayStyle.Flex;
        optionsMenu.style.display = DisplayStyle.None;
    }

    void QuitConfirmActive()
    {
        quitMenu.style.display = DisplayStyle.None;
        playMenu.style.display = DisplayStyle.Flex;
    }

    void QuitNegativeActive()
    {
        quitMenu.style.display = DisplayStyle.None;
        playMenu.style.display = DisplayStyle.Flex;
    }

    void ProfileButtonActive()
    {
        profileMenu.style.display = DisplayStyle.Flex;
        quitMenu.style.display = DisplayStyle.None;
        optionsMenu.style.display = DisplayStyle.None;
    }

    void ActiveMapActive()
    {
        StaticMap.visible = false;
        ActiveMap.visible = true;
    }

    void StaticMapActive() 
    {
        StaticMap.visible = true;
        ActiveMap.visible = false;
    }
}
