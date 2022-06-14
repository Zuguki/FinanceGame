using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Main;
using Science;
using TMPro;
using Unity.VisualScripting;
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
                                  - Liabilities.Sum(exp => exp.Price);

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

    private static TextMeshProUGUI _statTitle;
    private static GameObject _statTexts;
    private static GameObject _statAssets;
    private static GameObject _statLiabilities;
        
    private static int _mood = 5;

    private const float EventTime = 2f;

    private readonly Color _defaultColor = Color.white;
    private readonly Color _upgradeColor = Color.green;
    private readonly Color _downgradeColor = Color.red;

    private void Awake()
    {
        _statTitle = playerInfoUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        _statTexts = playerInfoUI.transform.GetChild(1).gameObject;
        _statAssets = playerInfoUI.transform.GetChild(2).gameObject;
        _statLiabilities = playerInfoUI.transform.GetChild(3).gameObject;
        
        _cashText = _statTexts.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cashFlowText = _statTexts.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _incomeText = _statTexts.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _expensesText = _statTexts.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        _assetsText = _statTexts.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        _liabilitiesText = _statTexts.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        _freeTimeText = _statTexts.transform.GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        _moodText = _statTexts.transform.GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
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
        UpdateValue(_liabilitiesText, Liabilities.Sum(pas => pas.Price));
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

    public static void ShowMain()
    {
        _statTitle.text = "Основная информация";
        _statAssets.SetActive(false);
        _statLiabilities.SetActive(false);
        _statTexts.SetActive(true);
    }

    public static void ShowAssets(GameObject prefab, GameObject eventUI)
    {
        _statTitle.text = "Активы";
        _statTexts.SetActive(false);
        _statLiabilities.SetActive(false);
        _statAssets.SetActive(true);
        DestroyElements(_statAssets);

        foreach (var asset in Assets)
        {
            var pref = Instantiate(prefab, _statAssets.transform);
            pref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asset.Title;
            
            var btn = pref.GetComponent<Button>();
            btn.onClick.AddListener(() => ShowByAsset(asset, eventUI));
        }
    }

    private static void DestroyElements(GameObject item)
    {
        foreach (Transform child in item.transform)
            Destroy(child.gameObject);
    }

    private static void ShowByAsset(Asset asset, GameObject eventUI)
    {
        eventUI.SetActive(true);
        var title = eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var info = eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var success = eventUI.transform.GetChild(2).GetComponent<Button>();
        var cancel = eventUI.transform.GetChild(3).GetComponent<Button>();

        title.text = asset.Title;
        info.text = $"У вас есть имущество под названием: {asset.Title}\n" +
                    $"Цена имущества: {asset.Price}\n" +
                    $"Цена продажи имущества: {asset.CurrentPrice}";
        
        success.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
        success.onClick.AddListener(() => Success(asset, eventUI));
        cancel.onClick.AddListener(() => Cancel(eventUI));
    }

    private static void Cancel(GameObject eventUI) =>
        eventUI.SetActive(false);

    private static void Success(Asset asset, GameObject eventUI)
    {
        Assets.Remove(asset);
        Cash += asset.CurrentPrice;
        eventUI.SetActive(false);
    }

    public static void ShowLiabilities(GameObject buttonPrefab, GameObject eventUI)
    {
        
        _statTitle.text = "Пассивы";
        _statAssets.SetActive(false);
        _statTexts.SetActive(false);
        _statLiabilities.SetActive(true);
        DestroyElements(_statLiabilities);

        foreach (var liabilities in Liabilities)
        {
            var pref = Instantiate(buttonPrefab, _statLiabilities.transform);
            pref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = liabilities.Title;
            
            var btn = pref.GetComponent<Button>();
            btn.onClick.AddListener(() => ShowByLiability(liabilities, eventUI));
        }
    }

    private static void ShowByLiability(Passive liability, GameObject eventUI)
    {
        eventUI.SetActive(true);
        var title = eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var info = eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var success = eventUI.transform.GetChild(2).GetComponent<Button>();
        var cancel = eventUI.transform.GetChild(3).GetComponent<Button>();

        title.text = liability.Title;
        info.text = $"У вас есть пассив под названием: {liability.Title}\n" +
                    $"Пассив обходится вам в: {liability.Price}";
        
        success.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
        success.onClick.AddListener(() => Cancel(eventUI));
        cancel.onClick.AddListener(() => Cancel(eventUI));
    }
}