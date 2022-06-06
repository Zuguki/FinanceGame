using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static bool NeedsUpdate = true;

    [SerializeField] private GameObject playerInfoUI;

    private const int TimePerMonth = 100;

    public static int Cash = 10000000;
    public static List<Income> Incomes = new();
    public static List<Expense> Expenses = new();
    public static List<Passive> Liabilities = new();
    public static List<Asset> Assets = new();

    public static int CashFlow => Incomes.Sum(inc => inc.Value) + Assets.Sum(asset => asset.IncomeValue)
                                  - (Expenses.Sum(exp => exp.Value)
                                     + Liabilities.Sum(pas => pas.Value));

    public static int FreeTime => TimePerMonth - (Incomes.Sum(inc => inc.Time)
                                                  + Expenses.Sum(exp => exp.Time)
                                                  + Liabilities.Sum(pas => pas.Time) +
                                                  Assets.Sum(asset => asset.NeedsTime));

    public static int Mood
    {
        get => _mood;
        set
        {
            _mood = value switch
            {
                > 10 => 10,
                < 0 => 0,
                _ => value
            };
        }
    }

    private TextMeshProUGUI _cashText,
        _cashFlowText,
        _incomeText,
        _expensesText,
        _assetsText,
        _liabilitiesText,
        _freeTimeText,
        _moodText;

    private static int _mood = 5;

    private const float EventTime = 2f;

    private readonly Color _defaultColor = Color.black;
    private readonly Color _upgradeColor = Color.blue;
    private readonly Color _downgradeColor = Color.red;

    private void Awake()
    {
        _cashText = playerInfoUI.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cashFlowText = playerInfoUI.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _incomeText = playerInfoUI.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        _expensesText = playerInfoUI.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        _assetsText = playerInfoUI.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        _liabilitiesText = playerInfoUI.transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        _freeTimeText = playerInfoUI.transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
        _moodText = playerInfoUI.transform.GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (NeedsUpdate)
            UpdateUIValues();
    }

    private void UpdateUIValues()
    {
        RemoveFinishedAssets();

        UpdateValue(_cashText, Cash);
        UpdateValue(_cashFlowText, CashFlow);
        UpdateValue(_incomeText, Incomes.Sum(inc => inc.Value));
        UpdateValue(_expensesText, Expenses.Sum(exp => exp.Value));
        UpdateValue(_assetsText, Assets.Sum(asset => asset.Price));
        UpdateValue(_liabilitiesText, Liabilities.Sum(pas => pas.Value));
        UpdateValue(_freeTimeText, FreeTime);
        UpdateValue(_moodText, Mood);

        NeedsUpdate = false;
    }

    private static void RemoveFinishedAssets() =>
        Assets = Assets.Where(asset => asset.ExpirationDate != 0).ToList();

    private void UpdateValue(TMP_Text stat, int value)
    {
        var good = int.TryParse(stat.text, out var statValue);
        if (!good || statValue == value)
        {
            stat.text = value.ToString();
            return;
        }

        StartCoroutine(ChangeColor(int.Parse(stat.text) < value, stat));
        stat.text = value.ToString();
    }

    private IEnumerator ChangeColor(bool isUpgrade, Graphic stat)
    {
        stat.color = isUpgrade ? _upgradeColor : _downgradeColor;

        yield return new WaitForSeconds(EventTime);
        stat.color = _defaultColor;
    }
}