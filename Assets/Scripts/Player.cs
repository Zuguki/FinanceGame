using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Main;
using Science;
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
    public static List<Education> Educations = new();

    public static int CashFlow => Incomes.Sum(inc => inc.Value)
                                  - Liabilities.Sum(exp => exp.Value);

    public static int FreeTime => TimePerMonth - (+ Expenses.Sum(exp => exp.Time)
                                                  + Liabilities.Sum(pas => pas.ExpirationDate)
                                                  + Assets.Sum(asset => asset.NeedsTime)
                                                  + Educations.Where(educ => educ.ExpirationDate > 0)
                                                      .Sum(educ => educ.NeedsTime));

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

    private readonly Color _defaultColor = Color.white;
    private readonly Color _upgradeColor = Color.green;
    private readonly Color _downgradeColor = Color.red;

    private void Awake()
    {
        var texts = playerInfoUI.transform.GetChild(1).gameObject;
        
        _cashText = texts.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cashFlowText = texts.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _incomeText = texts.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _expensesText = texts.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        _assetsText = texts.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        _liabilitiesText = texts.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        _freeTimeText = texts.transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        _moodText = texts.transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (NeedsUpdate)
            UpdateUIValues();
    }

    private void UpdateUIValues()
    {
        RemoveFinishedAssets();
        RemoveFinishedPassives();
        UpdateAssetsRatioValue();

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

    private static void RemoveFinishedPassives() =>
        Liabilities = Liabilities.Where(passive => passive.ExpirationDate != 0).ToList();

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

    private static void UpdateAssetsRatioValue()
    {
        if (Educations.Count == 0)
            return;
        
        var educationRatio = 1 + Educations.Where(educ => educ.ExpirationDate <= 0)
            .Sum(educ => educ.RatioOfUpgrade) * 0.01f;

        foreach (var income in Incomes.Where(income => income.RatioOfUpgrade < educationRatio))
            income.RatioOfUpgrade = educationRatio;
    }
}