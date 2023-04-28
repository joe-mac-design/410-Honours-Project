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
}