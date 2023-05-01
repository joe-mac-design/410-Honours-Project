using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Play Menu
    public Button playButton;
    public VisualElement StaticMap;
    public Button StaticNAButton;
    public VisualElement ActiveMap;
    public Button ActiveNAButton;
    public Button MapPointer_1;
    public Button MapPointer_2;
    public Button MapPointer_3;
    public VisualElement LessonBox_1;
    public VisualElement LessonBox_2;
    public VisualElement LessonBox_3;
    public Button LessonBoxButton_1;
    public Button LessonBoxButton_2;
    public Button LessonBoxButton_3;

    // Options Menu
    public Button optionsButton;

    // Quit Menu
    public Button quitButton;
    public Button quitConfirmButton;
    public Button quitNegativeButton;

    // Profile Menu
    public Button profileButton;
    public Button IconButton;
    public Button IconSaveButton;
    public Button BadgesButton;
    public Button NicknameButton;
    public Button NicknameSaveButton;
    public Button LessonCompleteButton;
    public Button RestartButton;

    [SerializeField] private string[] _ProfileMenuSaveButtonTextArray;

    // Visual Elements
    public VisualElement playMenu;
    public VisualElement optionsMenu;
    public VisualElement quitMenu;
    public VisualElement profileMenu;
    public VisualElement ProfileMenuOptionsContainer;
    public VisualElement IconContainer;
    public VisualElement BadgesContainer;
    public VisualElement NicknameContainer;
    public VisualElement PostGameContainer;
    public VisualElement LaunchContainer;

    public VisualElement MainContainer;
    public VisualElement GameContainer;
    public VisualElement LessonContainer;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        MainContainer = root.Q<VisualElement>("MainContainer");
        GameContainer = root.Q<VisualElement>("GameContainer");
        LaunchContainer = root.Q<VisualElement>("LaunchContainer");

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

        ProfileMenuOptionsContainer = root.Q<VisualElement>("ProfileOptionsContainer");
        IconContainer = root.Q<VisualElement>("IconContainer");
        BadgesContainer = root.Q<VisualElement>("BadgesContainer");
        NicknameContainer = root.Q<VisualElement>("NicknameContainer");

        LessonContainer = root.Q<VisualElement>("LessonCompleteContainer");
        LessonCompleteButton = root.Q<Button>("GameCompleteContinueButton");

        RestartButton = root.Q<Button>("RestartBtn");

        IconButton = root.Q<Button>("IconBtn");
        IconSaveButton = root.Q<Button>("IconSaveButton");

        BadgesButton = root.Q<Button>("BadgesBtn");

        NicknameButton = root.Q<Button>("NicknameBtn");
        NicknameSaveButton = root.Q<Button>("NicknameSaveButton");

        StaticMap = root.Q<VisualElement>("StaticMapContainer");
        StaticNAButton = root.Q<Button>("StaticNA");
        ActiveMap = root.Q<VisualElement>("ActiveMapContainer");
        ActiveNAButton = root.Q<Button>("ActiveNA");

        MapPointer_1 = root.Q<Button>("MapPointer-1");
        LessonBox_1 = root.Q<VisualElement>("LessonBox-1");
        LessonBoxButton_1 = root.Q<Button>("LessonStartButton");

        PostGameContainer = root.Q<VisualElement>("PostGameContainer");

        MapPointer_2 = root.Q<Button>("MapPointer-2");
        LessonBox_2 = root.Q<VisualElement>("LessonBox-2");

        MapPointer_3 = root.Q<Button>("MapPointer-3");
        LessonBox_3 = root.Q<VisualElement>("LessonBox-3");

        optionsButton.clicked += OptionsButtonActive;
        quitButton.clicked += QuitButtonActive;
        playButton.clicked += PlayButtonActive;
        profileButton.clicked += ProfileButtonActive;

        IconButton.clicked += IconContainerActive;
        IconSaveButton.clicked += IconSaveButtonActive;

        BadgesButton.clicked += BadgesContainerActive;

        NicknameButton.clicked += NicknameContainerActive;
        NicknameSaveButton.clicked += NicknameSaveButtonActive;

        LessonCompleteButton.clicked += LessonCompleteButtonActive;

        RestartButton.clicked += RestartButtonActive;

        quitConfirmButton.clicked += QuitConfirmActive;
        quitNegativeButton.clicked += QuitNegativeActive;

        StaticNAButton.clicked += ActiveMapActive;
        ActiveNAButton.clicked += StaticMapActive;

        MapPointer_1.clicked += LessonBox_1Active;
        LessonBoxButton_1.clicked += LessonStartButton_1Active;

        MapPointer_2.clicked += LessonBox_2Active;

        MapPointer_3.clicked += LessonBox_3Active;
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
        // exit the game and in the editor, stop playing
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void QuitNegativeActive()
    {
        quitMenu.style.display = DisplayStyle.None;
        playMenu.style.display = DisplayStyle.Flex;
    }

    void ProfileButtonActive()
    {
        // If the ProfileButton is clicked, the ProfileMenu will be enabled, if it is clicked again, it will be disabled
        if (profileMenu.style.display == DisplayStyle.None)
        {
            profileMenu.style.display = DisplayStyle.Flex;
            quitMenu.style.display = DisplayStyle.None;
            optionsMenu.style.display = DisplayStyle.None;
        }
        else
        {
            profileMenu.style.display = DisplayStyle.None;
        }
    }

    void ActiveMapActive()
    {
        StaticMap.visible = false;
        ActiveMap.visible = true;
    }

    void StaticMapActive() 
    {
        StaticMap.visible = true;
        LessonBox_1.visible = false;
        LessonBox_2.visible = false;
        LessonBox_3.visible = false;
        ActiveMap.visible = false;
    }

    void LessonBox_1Active()
    {
        // Clicking the button will enable the LessonBox, clicking it again while disable it the lessonbox
        if (LessonBox_1.visible == false)
        {
            LessonBox_1.visible = true;
        }
        else
        {
            LessonBox_1.visible = false;
        }
    }

    void LessonStartButton_1Active()
    {
        MainContainer.style.display = DisplayStyle.None;
        GameContainer.style.display = DisplayStyle.Flex;
    }

    void LessonBox_2Active()
    {
        // Clicking the button will enable the LessonBox, clicking it again while disable it the lessonbox
        if (LessonBox_2.visible == false)
        {
            LessonBox_2.visible = true;
        }
        else
        {
            LessonBox_2.visible = false;
        }
    }

    void LessonBox_3Active()
    {
        // Clicking the button will enable the LessonBox, clicking it again while disable it the lessonbox
        if (LessonBox_3.visible == false)
        {
            LessonBox_3.visible = true;
        }
        else
        {
            LessonBox_3.visible = false;
        }
    }

    void IconContainerActive() 
    {
        IconContainer.style.display = DisplayStyle.Flex;
        BadgesContainer.style.display = DisplayStyle.None;
        NicknameContainer.style.display = DisplayStyle.None;
    }

    async void IconSaveButtonActive() 
    {
        IconSaveButton.text = _ProfileMenuSaveButtonTextArray[0];
        await Task.Delay(1000);
        IconSaveButton.text = _ProfileMenuSaveButtonTextArray[1];
        await Task.Delay(1000);
        IconSaveButton.text = _ProfileMenuSaveButtonTextArray[2];
        await Task.Delay(1000);
        IconSaveButton.text = _ProfileMenuSaveButtonTextArray[3];
    }

    void BadgesContainerActive()
    {
        IconContainer.style.display = DisplayStyle.None;
        BadgesContainer.style.display = DisplayStyle.Flex;
        NicknameContainer.style.display = DisplayStyle.None;
    }

    void NicknameContainerActive()
    {
        IconContainer.style.display = DisplayStyle.None;
        BadgesContainer.style.display = DisplayStyle.None;
        NicknameContainer.style.display = DisplayStyle.Flex;
    }

    async void NicknameSaveButtonActive() 
    {
        NicknameSaveButton.text = _ProfileMenuSaveButtonTextArray[0];
        await Task.Delay(1000);
        NicknameSaveButton.text = _ProfileMenuSaveButtonTextArray[1];
        await Task.Delay(1000);
        NicknameSaveButton.text = _ProfileMenuSaveButtonTextArray[2];
        await Task.Delay(1000);
        NicknameSaveButton.text = _ProfileMenuSaveButtonTextArray[3];
    }

    void LessonCompleteButtonActive()
    {
        LessonContainer.style.display = DisplayStyle.None;
        PostGameContainer.style.display = DisplayStyle.Flex;
    }

    void RestartButtonActive()
    {
        // quit the game or quit the editor
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
 }
