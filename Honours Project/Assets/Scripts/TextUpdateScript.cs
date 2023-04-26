using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TextUpdateScript : MonoBehaviour
{
    [SerializeField] private Button ContinueBtn;
    [SerializeField] private Button FinishBtn;
    [SerializeField] private Button LSBtn;


    [SerializeField] private Label TutText;
    [SerializeField] private Label LsText;

    [SerializeField] private string[] _newTexts;
    [SerializeField] private string[] _lsTexts;

    [SerializeField] private VisualElement _backgroundElement;
    [SerializeField] private Texture2D[] _newBackgroundImages;

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
        LsText = root.Q<Label>("SubText");

        ContinueBtn = root.Q<Button>("ContinueBtn");
        FinishBtn = root.Q<Button>("FinishBtn");
        LSBtn = root.Q<Button>("SignInBtn");

        _backgroundElement = root.Q<VisualElement>("TutBackground");

        ContinueBtn.clicked += OnCtnButtonClicked;
        FinishBtn.clicked += OnFsnButtonClicked;
        LSBtn.clicked += OnLSButtonClicked;
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

    private void OnLSButtonClicked()
    {
        _currentTextIndex = (_currentTextIndex + 1) % _lsTexts.Length;
        LsText.text = _lsTexts[_currentTextIndex];

        if (_currentTextIndex == _lsTexts.Length - 3)
        {
            LSMenu.style.display = DisplayStyle.None;
            PCMenu.style.display = DisplayStyle.Flex;
        }
    }
}