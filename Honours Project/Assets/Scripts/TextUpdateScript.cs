using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public class TextUpdateScript : MonoBehaviour
{
    [SerializeField] private Button ContinueBtn;
    [SerializeField] private Button FinishBtn;
    [SerializeField] private Button _LoginButton;

    [SerializeField] private Label TutText;
    [SerializeField] private Label _LoginSubText;

    [SerializeField] private string[] _newTexts;
    [SerializeField] private string[] _LoginTextArray;

    [SerializeField] private string[] _LoginButtonTextArray;

    [SerializeField] private VisualElement _backgroundElement;
    [SerializeField] private Texture2D[] _newBackgroundImages;

    [SerializeField] private Texture2D LoginButtonBGImage;

    [SerializeField] private VisualElement LSTopWater;
    [SerializeField] private VisualElement LSBotWater;

    // Visual Elements
    public VisualElement LSMenu;
    public VisualElement PCMenu;
    public VisualElement TutMenu;
    public VisualElement MainMenu;

    private int _currentTextIndex = 0;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        LSMenu = root.Q<VisualElement>("LaunchContainer");
        PCMenu = root.Q<VisualElement>("ProfileCreation");
        TutMenu = root.Q<VisualElement>("TutorialContainer");
        MainMenu = root.Q<VisualElement>("MainContainer");

        TutText = root.Q<Label>("TutText");
        _LoginSubText = root.Q<Label>("SubText");

        ContinueBtn = root.Q<Button>("ContinueBtn");
        FinishBtn = root.Q<Button>("FinishBtn");
        _LoginButton = root.Q<Button>("SignInBtn");

        _backgroundElement = root.Q<VisualElement>("TutBackground");

        LSTopWater = root.Q<VisualElement>("LSTopWater");
        LSBotWater = root.Q<VisualElement>("LSBotWater");

        ContinueBtn.clicked += OnCtnButtonClicked;
        FinishBtn.clicked += OnFsnButtonClicked;
        _LoginButton.clicked += OnLSButtonClicked;
    }

    private void OnCtnButtonClicked()
    {
        _currentTextIndex = (_currentTextIndex + 1) % _newTexts.Length;
        TutText.text = _newTexts[_currentTextIndex];

        if (_currentTextIndex == _newTexts.Length - 1)
        {
            ContinueBtn.style.display = DisplayStyle.None;
            FinishBtn.style.display = DisplayStyle.Flex;
        }

        _backgroundElement.style.backgroundImage = new StyleBackground(_newBackgroundImages[_currentTextIndex]);
    }

    private void OnFsnButtonClicked()
    {
        _currentTextIndex = 0;
        TutText.text = _newTexts[_currentTextIndex];

        ContinueBtn.style.display = DisplayStyle.Flex;
        FinishBtn.style.display = DisplayStyle.None;

        TutMenu.style.display = DisplayStyle.None;
        MainMenu.style.display = DisplayStyle.Flex;

        _backgroundElement.style.backgroundImage = new StyleBackground(_newBackgroundImages[_currentTextIndex]);
    }

    private async void OnLSButtonClicked()
    {
        _LoginSubText.text = _LoginTextArray[0];
        _LoginButton.text = _LoginButtonTextArray[0];

        await Task.Delay(1200);
        _LoginSubText.text = _LoginTextArray[1];
        _LoginButton.text = _LoginButtonTextArray[1];
        _LoginButton.Q<VisualElement>("SignInBtn").style.backgroundImage = new StyleBackground(LoginButtonBGImage);

        while (LSTopWater.style.translate.value.y.value > -199)
        {
            float newYValue = Mathf.Lerp(LSBotWater.style.translate.value.y.value, 200, 0.1f);
            LSBotWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            newYValue = Mathf.Lerp(LSTopWater.style.translate.value.y.value, -200, 0.1f);
            LSTopWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            await Task.Delay(2);
        }
        await Task.Delay(1200);
        _LoginSubText.text = _LoginTextArray[2];
        _LoginButton.text = _LoginButtonTextArray[2];
        _LoginButton.Q<VisualElement>("SignInBtn").style.backgroundImage = null;

        while (LSTopWater.style.translate.value.y.value < -1)
        {
            float newYValue = Mathf.Lerp(LSBotWater.style.translate.value.y.value, 0, 0.1f);
            LSBotWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            newYValue = Mathf.Lerp(LSTopWater.style.translate.value.y.value, 0, 0.1f);
            LSTopWater.style.translate = new StyleTranslate(new Translate(0, newYValue));
            await Task.Delay(2);
        }
        await Task.Delay(1200);

        LSMenu.style.display = DisplayStyle.None;
        PCMenu.style.display = DisplayStyle.Flex;
    }
}