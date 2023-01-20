using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("StartPanel")]
    [Space]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private Button _startButton;
    [SerializeField] private Image _imageActiveFruit;
    [SerializeField] private TextMeshProUGUI _startFruitCollectText;

    [Header("GamePanel")]
    [Space]
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private TextMeshProUGUI _goalText;
    [SerializeField] private Image _imageActiveFruitLeft;
    [SerializeField] private Image _imageActiveFruitRight;
    private int _goalFruit;
    private string _goalNameFruit;

    [Header("FinishPanel")]
    [Space]
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Button _finishButton;

    [Header("IconArray")]
    [Space]
    [SerializeField] private Sprite[] _fruitSprite;
    [SerializeField] private string[] _goalString;

    private Man _manScript;
    private VirtualCamera _virtualCameraScript;

    public string goalNameFruit => _goalNameFruit;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _finishButton.onClick.AddListener(NextLevel);
        _manScript = FindObjectOfType<Man>();
        _virtualCameraScript = FindObjectOfType<VirtualCamera>();
    }

    private void Start()
    {
        Time.timeScale = 0f;
        GenerateGoal();
    }

    private void StartGame()
    {
        _startPanel.SetActive(false);
        _gamePanel.SetActive(true);
        Time.timeScale = 1f;
        _virtualCameraScript.GameCameraOn();
    }

    private void SetImage()
    {
        if(_goalNameFruit == "Pineapple")
        {
            _imageActiveFruit.sprite = _fruitSprite[2];
            _imageActiveFruitLeft.sprite = _fruitSprite[2];
            _imageActiveFruitRight.sprite = _fruitSprite[2];
        }
        else if (_goalNameFruit == "Orange")
        {
            _imageActiveFruit.sprite = _fruitSprite[1];
            _imageActiveFruit.rectTransform.localScale = new Vector3(0.2f, 0.26f, 0.3f);
            _imageActiveFruitLeft.sprite = _fruitSprite[1];
            _imageActiveFruitLeft.rectTransform.localScale = new Vector3(0.15f, 0.4f, 0.26f);
            _imageActiveFruitRight.sprite = _fruitSprite[1];
            _imageActiveFruitRight.rectTransform.localScale = new Vector3(0.15f, 0.4f, 0.26f);
        }
        else if (_goalNameFruit == "Pear")
        {
            _imageActiveFruit.sprite = _fruitSprite[0];
            _imageActiveFruitLeft.sprite = _fruitSprite[0];
            _imageActiveFruitRight.sprite = _fruitSprite[0];
        }

    }

    private void GenerateGoal()
    {
        _goalFruit = Random.Range(1, 6);
        _goalNameFruit = _goalString[Random.Range(0, 3)];
        _goalText.text = _goalFruit + " " + _goalNameFruit;
        _startFruitCollectText.text = _goalFruit + " " + _goalNameFruit;
        SetImage();
    }

    public void GoalUpdate()
    {
        _goalFruit -= 1;
        _goalText.text = _goalFruit + " " + _goalNameFruit;

        if (_goalFruit == 0)
        {
            FinishGame();
        }

    }

    private void FinishGame()
    {
        Conveyor conveyor;
        conveyor = FindObjectOfType<Conveyor>();
        conveyor.gameObject.SetActive(false);

        _virtualCameraScript.FinishCameraOn();
        _gamePanel.SetActive(false);
        _finishPanel.SetActive(true);
        _manScript.animationMan.SetTrigger("Dance");
    }

    private void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

}
