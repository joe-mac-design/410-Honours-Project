using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public Button profileButton;

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
        profileButton = root.Q<Button>("ProfileButton");

        optionsMenu = root.Q<VisualElement>("OptionsMenuContainer");
        quitMenu = root.Q<VisualElement>("QuitMenuContainer");
        playMenu = root.Q<VisualElement>("PlayMenuContainer");
        profileMenu = root.Q<VisualElement>("ProfileMenuContainer");

        optionsButton.clicked += OptionsButtonActive;
        quitButton.clicked += QuitButtonActive;
        playButton.clicked += PlayButtonActive;
        profileButton.clicked += ProfileButtonActive;
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

    void ProfileButtonActive()
    {
        profileMenu.style.display = DisplayStyle.Flex;
        quitMenu.style.display = DisplayStyle.None;
        optionsMenu.style.display = DisplayStyle.None;
    }
}
