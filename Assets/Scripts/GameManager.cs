using HoloToolkit.Unity;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public event OnTransmitterFoundChangeDelegate OnTransmitterFoundChange;
    public delegate void OnTransmitterFoundChangeDelegate(bool isTransmitterFound);

    public event OnTransparencyChangeDelegate OnTransparencyChange;
    public delegate void OnTransparencyChangeDelegate(bool isTransparent);

    public event OnProstateChangeDelegate OnProstateChange;
    public delegate void OnProstateChangeDelegate(ProstateType prostate);

    public event OnDREStageChangeDelegate OnDREStageChange;
    public delegate void OnDREStageChangeDelegate(DREStage dreStage);

    /// <summary>
    /// Set true when transmitter is found by Vuforia
    /// </summary>
    [SerializeField]
    private bool _isTransmitterFound;
    public bool IsTransmitterFound
    {
        get
        {
            return _isTransmitterFound;
        }
        set
        {
            if (_isTransmitterFound == value) return;
            _isTransmitterFound = value;
            if (OnTransmitterFoundChange != null)
                OnTransmitterFoundChange(_isTransmitterFound);
        }
    }

    /// <summary>
    /// Set transparency of the bench top model
    /// </summary>
    [SerializeField]
    private bool _isTransparent = true;
    public bool IsTransparent
    {
        get
        {
            return _isTransparent;
        }
        set
        {
            if (_isTransparent == value) return;
            _isTransparent = value;
            if (OnTransparencyChange != null)
                OnTransparencyChange(_isTransparent);
        }
    }

    /// <summary>
    /// Set the prostate type to be shown in the model
    /// </summary>
    [SerializeField]
    private ProstateType _prostate = ProstateType.Normal;
    public ProstateType Prostate
    {
        get
        {
            return _prostate;
        }
        set
        {
            if (_prostate == value) return;
            _prostate = value;
            if (OnProstateChange != null)
                OnProstateChange(_prostate);
        }
    }

    [SerializeField]
    private DREStage _dreStage = DREStage.Anus;
    public DREStage DREStage
    {
        get
        {
            return _dreStage;
        }
        set
        {
            if (_dreStage == value) return;
            _dreStage = value;
            if (OnDREStageChange != null)
                OnDREStageChange(_dreStage);
        }
    }

    public bool ShowLabel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
