using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;

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
    
    public static int CashFlow => Incomes.Sum(inc => inc.Value) + Assets.Sum(asset => asset.Value) 
                                  - (Expenses.Sum(exp => exp.Value) 
                                     + Liabilities.Sum(pas => pas.Value));

    public static int FreeTime => TimePerMonth - (Incomes.Sum(inc => inc.Time)
                                               + Expenses.Sum(exp => exp.Time)
                                               + Liabilities.Sum(pas => pas.Time) +
                                               Assets.Sum(asset => asset.Time));

    public static int Mood
    {
        get => Mood;
        set
        {
            Mood = value switch
            {
                > 10 => 10,
                < 0 => 0,
                _ => value
            };
        }
    }

    private TextMeshProUGUI _cashText, _cashFlowText, _incomeText, _expensesText, _assetsText, _liabilitiesText,
        _freeTimeText, _moodText;

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
        _cashText.text = Cash.ToString();
        _cashFlowText.text = CashFlow.ToString();
        _incomeText.text = Incomes.Sum(inc => inc.Value).ToString();
        _expensesText.text = Expenses.Sum(exp => exp.Value).ToString();
        _assetsText.text = Assets.Sum(asset => asset.Price).ToString();
        _liabilitiesText.text = Liabilities.Sum(pas => pas.Value).ToString();
        _freeTimeText.text = FreeTime.ToString();
        _moodText.text = Mood.ToString();

        NeedsUpdate = false;
    }
}
