using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public class TextUpdateScript : MonoBehaviour
{
    // Launch Menu
    public VisualElement _LaunchContainer;
    public VisualElement _LaunchSequenceContainer;
    public VisualElement _LaunchProfileCreationContainer;
    public VisualElement _LaunchSqeuenceProfileCreationConfirmContainer;
    [SerializeField] private Button _LaunchLoginButton;
    [SerializeField] private Label _LaunchButtonSubText;
    [SerializeField] private Texture2D _LoginButtonBGImage;
    [SerializeField] private string[] _LoginTextArray;
    [SerializeField] private string[] _LoginButtonTextArray;
    [SerializeField] private VisualElement _LaunchTopWater;
    [SerializeField] private VisualElement _LaunchBotWater;
    [SerializeField] private VisualElement _LaunchConfirmYesNoContainer;
    [SerializeField] private VisualElement _LaunchConfirmLoadingContainer;

    // Tutorial Menu
    public VisualElement _TutorialContainer;
    [SerializeField] private Button _TutorialContinueBtn;
    [SerializeField] private Button _TutorialFinishBtn;
    [SerializeField] private Label _TutorialText;
    [SerializeField] private string[] _TutorialTextArray;
    [SerializeField] private VisualElement _TutorialOpacityBackground;
    [SerializeField] private Texture2D[] _TutorialOpacityBackgroundImageArray;
    private int _currentTextIndex = 0;

    // Profile Customization Menu
    [SerializeField] private Button _ProfileCreationContinueButton;
    [SerializeField] private Button _ProfileConfirmButton;
    [SerializeField] private Button _ProfileNegativeButton;
    [SerializeField] private Label _ProfileConfirmLabel;

    // Main Menu
    public VisualElement _MainContainer;

    // Game Menu
    [SerializeField] private VisualElement _GameContainer;
    [SerializeField] private VisualElement _GameLessonCompleteContainer;
    //Game Tutorial
    [SerializeField] private VisualElement _GameTutorialContainer;
    [SerializeField] private Button _GameContinueButton;
    [SerializeField] private Button _GameFinishButton;
    [SerializeField] private Label _GameTutText;
    [SerializeField] private string[] _GameTutTextArray;
    // Game Pause
    [SerializeField] private VisualElement _GamePauseContainer;
    [SerializeField] private VisualElement _GameQuitMenuContainer;
    [SerializeField] private Button _GamePauseConfirmBtn;
    [SerializeField] private Button _GamePauseNegativeBtn;
    [SerializeField] private Button _GamePauseButton;
    [SerializeField] private Button _GameResumeButton;
    [SerializeField] private Button _GameOptionsButton;
    [SerializeField] private Button _GameSaveButton;
    [SerializeField] private string[] _GameSaveButtonTextArray;
    [SerializeField] private Button _GameSaveQuitButton;
    [SerializeField] private VisualElement _GamePauseOptions;
    [SerializeField] private Button _GamePauseOptionsSaveButton;
    [SerializeField] private string[] _GamePauseOptionsSaveButtonTextArray;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _LaunchContainer = root.Q<VisualElement>("LaunchContainer");
        _LaunchSequenceContainer = root.Q<VisualElement>("LaunchSequence");
        _LaunchProfileCreationContainer = root.Q<VisualElement>("ProfileCreation");
        _LaunchSqeuenceProfileCreationConfirmContainer = root.Q<VisualElement>("ConfirmMenuContainer");
        _TutorialContainer = root.Q<VisualElement>("TutorialContainer");
        _MainContainer = root.Q<VisualElement>("MainContainer");

        _LaunchConfirmYesNoContainer = root.Q<VisualElement>("YNButtonContainer");
        _LaunchConfirmLoadingContainer = root.Q<VisualElement>("LoadingButtonContainer");
        _ProfileConfirmLabel = root.Q<Label>("LSCMLabel");

        _ProfileConfirmButton = root.Q<Button>("YesButton");
        _ProfileNegativeButton = root.Q<Button>("NoButton");

        _TutorialText = root.Q<Label>("TutText");
        _LaunchButtonSubText = root.Q<Label>("SubText");

        _ProfileCreationContinueButton = root.Q<Button>("ProfileCreationButton");

        _TutorialContinueBtn = root.Q<Button>("ContinueBtn");
        _TutorialFinishBtn = root.Q<Button>("FinishBtn");
        _LaunchLoginButton = root.Q<Button>("SignInBtn");

        _TutorialOpacityBackground = root.Q<VisualElement>("TutBackground");

        _LaunchTopWater = root.Q<VisualElement>("LSTopWater");
        _LaunchBotWater = root.Q<VisualElement>("LSBotWater");

        _GameContainer = root.Q<VisualElement>("GameContainer");
        _GameLessonCompleteContainer = root.Q<VisualElement>("LessonCompleteContainer");
        _GameTutorialContainer = root.Q<VisualElement>("GameTutBotWater");

        _GameTutText = root.Q<Label>("GameTutText");
        _GameContinueButton = root.Q<Button>("GameContinueBtn");
        _GameFinishButton = root.Q<Button>("GameFinishBtn");

        _GamePauseContainer = root.Q<VisualElement>("PauseMenuContainer");
        _GameQuitMenuContainer = root.Q<VisualElement>("GameQuitMenuContainer");
        _GamePauseConfirmBtn = root.Q<Button>("GamePauseConfirmBtn");
        _GamePauseNegativeBtn = root.Q<Button>("GamePauseNegativeBtn");

        _GamePauseButton = root.Q<Button>("GamePauseButton");
        _GameResumeButton = root.Q<Button>("PMResume");
        _GameOptionsButton = root.Q<Button>("PMOptions");
        _GameSaveButton = root.Q<Button>("PMSave");
        _GameSaveQuitButton = root.Q<Button>("PMSaveQuit");

        _GamePauseOptions = root.Q<VisualElement>("PMOptionsContainer");
        _GamePauseOptionsSaveButton = root.Q<Button>("PMOptionsSaveButton");

        _GameContinueButton.clicked += OnGCButtonClicked;
        _GameFinishButton.clicked += OnGFButtonClicked;

        _GamePauseButton.clicked += OnGPButtonClicked;
        _GameResumeButton.clicked += OnGRButtonClicked;
        _GameSaveButton.clicked += OnGSButtonClicked;
        _GameSaveQuitButton.clicked += OnGSQButtonClicked;

        _GameOptionsButton.clicked += OnGPOButtonClicked;
        _GamePauseOptionsSaveButton.clicked += OnGPOSButtonClicked;

        _GamePauseConfirmBtn.clicked += OnGPCButtonClicked;
        _GamePauseNegativeBtn.clicked += OnGPNButtonClicked;

        _TutorialContinueBtn.clicked += OnCtnButtonClicked;
        _TutorialFinishBtn.clicked += OnFsnButtonClicked;
        _LaunchLoginButton.clicked += OnLSButtonClicked;

        _ProfileCreationContinueButton.clicked += OnPCButtonClicked;
        _ProfileConfirmButton.clicked += OnLSCMYButtonClicked;
        _ProfileNegativeButton.clicked += OnLSCMNButtonClicked;
    }

    private void OnCtnButtonClicked()
    {
        _currentTextIndex = (_currentTextIndex + 1) % _TutorialTextArray.Length;
        _TutorialText.text = _TutorialTextArray[_currentTextIndex];

        if (_currentTextIndex == _TutorialTextArray.Length - 1)
        {
            _TutorialContinueBtn.style.display = DisplayStyle.None;
            _TutorialFinishBtn.style.display = DisplayStyle.Flex;
        }

        _TutorialOpacityBackground.style.backgroundImage = new StyleBackground(_TutorialOpacityBackgroundImageArray[_currentTextIndex]);
    }

    private void OnFsnButtonClicked()
    {
        _currentTextIndex = 0;
        _TutorialText.text = _TutorialTextArray[_currentTextIndex];

        _TutorialContinueBtn.style.display = DisplayStyle.Flex;
        _TutorialFinishBtn.style.display = DisplayStyle.None;

        _TutorialContainer.style.display = DisplayStyle.None;
        _MainContainer.style.display = DisplayStyle.Flex;

        _TutorialOpacityBackground.style.backgroundImage = new StyleBackground(_TutorialOpacityBackgroundImageArray[_currentTextIndex]);
    }

    private async void OnLSButtonClicked()
    {
        _LaunchButtonSubText.text = _LoginTextArray[0];
        _LaunchLoginButton.text = _LoginButtonTextArray[0];

        await Task.Delay(1200);
        _LaunchButtonSubText.text = _LoginTextArray[1];
        _LaunchLoginButton.text = _LoginButtonTextArray[1];
        _LaunchLoginButton.Q<VisualElement>("SignInBtn").style.backgroundImage = new StyleBackground(_LoginButtonBGImage);

        while (_LaunchTopWater.style.translate.value.y.value > -199)
        {
            float newYValue = Mathf.Lerp(_LaunchBotWater.style.translate.value.y.value, 200, 0.1f);
            _LaunchBotWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            newYValue = Mathf.Lerp(_LaunchTopWater.style.translate.value.y.value, -200, 0.1f);
            _LaunchTopWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            await Task.Delay(2);
        }
        await Task.Delay(1200);
        _LaunchButtonSubText.text = _LoginTextArray[2];
        _LaunchLoginButton.text = _LoginButtonTextArray[2];
        _LaunchLoginButton.Q<VisualElement>("SignInBtn").style.backgroundImage = null;

        while (_LaunchTopWater.style.translate.value.y.value < -1)
        {
            float newYValue = Mathf.Lerp(_LaunchBotWater.style.translate.value.y.value, 0, 0.1f);
            _LaunchBotWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            newYValue = Mathf.Lerp(_LaunchTopWater.style.translate.value.y.value, 0, 0.1f);
            _LaunchTopWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            await Task.Delay(2);
        }
        await Task.Delay(1200);

        _LaunchSequenceContainer.style.display = DisplayStyle.None;
        _LaunchProfileCreationContainer.style.display = DisplayStyle.Flex;
    }

    private void OnPCButtonClicked()
    {
        _LaunchProfileCreationContainer.style.display = DisplayStyle.None;
        _LaunchSqeuenceProfileCreationConfirmContainer.style.display = DisplayStyle.Flex;
    }

    private async void OnLSCMYButtonClicked()
    {
        await Task.Delay(1200);
        _LaunchConfirmYesNoContainer.style.display = DisplayStyle.None;
        _ProfileConfirmLabel.style.display = DisplayStyle.None;
        _LaunchConfirmLoadingContainer.style.display = DisplayStyle.Flex;
        await Task.Delay(1200);
        _LaunchContainer.style.display = DisplayStyle.None;
        _TutorialContainer.style.display = DisplayStyle.Flex;
    }

    private void OnLSCMNButtonClicked()
    {
        _LaunchSqeuenceProfileCreationConfirmContainer.style.display = DisplayStyle.None;
        _LaunchProfileCreationContainer.style.display = DisplayStyle.Flex;
    }

    private void OnGPButtonClicked() 
    {
        _GamePauseContainer.style.display = DisplayStyle.Flex;
    }

    private void OnGCButtonClicked() 
    {
        _currentTextIndex = (_currentTextIndex + 1) % _GameTutTextArray.Length;
        _GameTutText.text = _GameTutTextArray[_currentTextIndex];

        if (_currentTextIndex == _GameTutTextArray.Length - 1)
        {
            _GameContinueButton.style.display = DisplayStyle.None;
            _GameFinishButton.style.display = DisplayStyle.Flex;
        }

    }

    private async void OnGFButtonClicked() 
    {
        _GameTutorialContainer.style.display = DisplayStyle.None;

        await Task.Delay(15000);
        _GameLessonCompleteContainer.style.display = DisplayStyle.Flex;
    }

    private void OnGRButtonClicked() 
    {
        _GamePauseContainer.style.display = DisplayStyle.None;
    }

    private void OnGSQButtonClicked() 
    {
        _GameQuitMenuContainer.style.display = DisplayStyle.Flex;
    }

    private async void OnGPCButtonClicked() 
    {
        await Task.Delay(500);
        _GameQuitMenuContainer.style.display = DisplayStyle.None;
        _GamePauseContainer.style.display = DisplayStyle.None;
        _GameContainer.style.display = DisplayStyle.None;
        _MainContainer.style.display = DisplayStyle.Flex;
    }

    private void OnGPNButtonClicked() 
    {
        _GameQuitMenuContainer.style.display = DisplayStyle.None;
    }

    private async void OnGSButtonClicked() 
    {
        await Task.Delay(500);
        _GameSaveButton.text = _GameSaveButtonTextArray[0];
        await Task.Delay(500);
        _GameSaveButton.text = _GameSaveButtonTextArray[1];
        await Task.Delay(500);
        _GameSaveButton.text = _GameSaveButtonTextArray[2];
        await Task.Delay(500);
        _GameSaveButton.text = _GameSaveButtonTextArray[3];
    }

    private void OnGPOButtonClicked() 
    {
        _GamePauseOptions.style.display = DisplayStyle.Flex;
    }

    private async void OnGPOSButtonClicked()
    {
        await Task.Delay(500);
        _GamePauseOptionsSaveButton.text = _GamePauseOptionsSaveButtonTextArray[0];
        await Task.Delay(500);
        _GamePauseOptionsSaveButton.text = _GamePauseOptionsSaveButtonTextArray[1];
        await Task.Delay(500);
        _GamePauseOptionsSaveButton.text = _GamePauseOptionsSaveButtonTextArray[2];
        await Task.Delay(500);
        _GamePauseOptionsSaveButton.text = _GamePauseOptionsSaveButtonTextArray[3];

        await Task.Delay(250);
        _GamePauseOptions.style.display = DisplayStyle.None;
    }
}