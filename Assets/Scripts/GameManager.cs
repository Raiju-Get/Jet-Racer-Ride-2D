using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [field: SerializeField] public float Lives { get; set; }
    [SerializeField] private float timer;
    [SerializeField] private AnswerSet answerSet;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private RivalScript[] rivalScript = new RivalScript[3];
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject winnerUI;
    [SerializeField] private Image balloonUI;
    [SerializeField] private float startTimer;
    [SerializeField] private Image startTimerImage;
    [SerializeField] private GameObject startTimerPanel;
    [SerializeField] private Sprite[] sprite = new Sprite[4];
    [SerializeField] private Sprite winnerSprite;
    [SerializeField] private TextMeshProUGUI winnerName;
    [SerializeField] private PlaceTracker placeTracker;
    [SerializeField] private ButtonDeactivator buttonDeactivator;
    [SerializeField] private GameObject tutorialObject;
    [SerializeField] private GameObject tutorialPointer;
    [SerializeField] private GameObject correctAnswerPointer;
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject blocker;
    [SerializeField] private Animator[] carAnimatorList = new Animator[4];
    private GameStateMachine _currentState;
    private GameStateMachine _previousState;
    private float _tempTimer;
    private float _tempStartTimer;

    public Animator[] CarAnimatorList
    {
        get => carAnimatorList;
        set => carAnimatorList = value;
    }
    public float StartTimer
    {
        get => startTimer;
        set => startTimer = value;
    }

    public GameObject Blocker
    {
        get => blocker;
        set => blocker = value;
    }

    public TextMeshProUGUI WinnerName
    {
        get => winnerName;
        set => winnerName = value;
    }
    public Sprite[] NewSprite
    {
        get => sprite;
        set => sprite = value;
    }

    public Sprite WinnerSprite
    {
        get => winnerSprite;
        set => winnerSprite = value;
    }
    public Image StartTimerImage
    {
        get => startTimerImage;
        set => startTimerImage = value;
    }
    
    public Image BalloonUI
    {
        get => balloonUI;
        set => balloonUI = value;
    }

    public GameObject StartTimerPanel
    {
        get => startTimerPanel;
        set => startTimerPanel = value;
    }

    public GameObject TutorialObject
    {
        get => tutorialObject;
        set => tutorialObject = value;
    }

    public GameObject TutorialPointer
    {
        get => tutorialPointer;
        set => tutorialPointer = value;
    }
    
    public GameObject TutorialText
    {
        get => tutorialText;
        set => tutorialText = value;
    }
    
    public GameObject CorrectAnswerPointer
    {
        get => correctAnswerPointer;
        set => correctAnswerPointer = value;
    }
    public GameObject PlayerUI => playerUI;
    public GameObject Winner => winnerUI;
    public GameStateMachine CurrentState => _currentState;
    public readonly GameStateMachine _startMenu = new StartMenuState();
    public readonly GameStateMachine PlayState = new PlayState();
    private readonly GameStateMachine _pauseState = new PauseState();
    public readonly GameStateMachine WinState = new WinState();
    public readonly GameStateMachine LoseState = new LoseState();
    public readonly GameStateMachine TutorailState = new TutorailState();
    public AnswerSet AnswerSet => answerSet;
    public PlayerController PlayerController => playerController;
    public ButtonDeactivator ButtonDeactivator => buttonDeactivator;

    public RivalScript[] RivalScript => rivalScript;
    public float Timer { get; set; }
    public float TempTimer { get=>_tempTimer; set=>_tempTimer = value; }

    public PlaceTracker PlaceTracker => placeTracker;
    public bool isTutorial;
    public bool isReset;
    private static readonly int IsDriving = Animator.StringToHash("isDriving");


    private void Start()
    {
        for (int i = 0; i < CarAnimatorList.Length; i++)
        {
            CarAnimatorList[i].SetBool(IsDriving, false);
        }
        _tempTimer = timer;
        _tempStartTimer = startTimer;
    }
    
    public  void Update()
    {
        if (_currentState != null)
        {
            _currentState.UpdateGameState(this);
        }
    }
    public void StartState()
    {
        
        if (isTutorial)
        {
            SwitchState(TutorailState);
            
        }
        else
        {
            
            SwitchState(_startMenu);
            
        }

        isReset = false;
        startTimerPanel.SetActive(true);
        startTimerImage.gameObject.SetActive(true);
        startTimer = _tempStartTimer;
       
        
    }



    public void EndState()
    {
        _currentState.EndState(this);
    }

    public void PauseState()
    {
        _previousState = _currentState;
        SwitchState(_pauseState);
    }

    public void TutorialState()
    {
        isTutorial = true;
        TutorialPointer.SetActive(true);
    }

    public void ReturnState()
    {
        _currentState = _previousState;
        _currentState.TransitionState(this);
    }

    public void SwitchState(GameStateMachine state)
    {
        _currentState = state;
        state.EnterState(this);
        Debug.Log(_currentState);
    }
    
  
}

