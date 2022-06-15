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
    public static List<Passive> Liabilities = new();
    public static List<Asset> Assets = new();
    public static List<Education> Educations = new();

    public static int Incomes => Assets.Sum(asset => asset.IncomeValue);
    public static int Expenses => Liabilities.Sum(liab => liab.IncomeValue);

    public static int CashFlow => Incomes - Expenses;

    public static int FreeTime => TimePerMonth - (Liabilities.Sum(pas => pas.ExpirationDate)
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
    private static GameObject _statTexts, _statAssets, _statLiabilities, _statSciences, _statTargets;

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
        _statSciences = playerInfoUI.transform.GetChild(4).gameObject;
        _statTargets = playerInfoUI.transform.GetChild(5).gameObject;

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
        UpdateValue(_incomeText, Incomes);
        UpdateValue(_expensesText, Expenses);
        UpdateValue(_assetsText, Assets.Sum(asset => asset.CurrentPrice));
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
        var good = Converter.ConvertToInt(stat.text, out var statValue);
        if (!good || statValue == value)
        {
            stat.text = Converter.ConvertToString(value.ToString());
            return;
        }

        Converter.ConvertToInt(stat.text, out var val);
        StartCoroutine(ChangeColor(val < value, stat));
        stat.text = Converter.ConvertToString(value.ToString());
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

        foreach (var asset in Assets.Where(asset => asset.RatioOfUpgrade < educationRatio))
            asset.RatioOfUpgrade = educationRatio;
    }

    public static void ShowMain()
    {
        _statTitle.text = "Основная информация";
        _statAssets.SetActive(false);
        _statLiabilities.SetActive(false);
        _statSciences.SetActive(false);
        _statTargets.SetActive(false);
        _statTexts.SetActive(true);
    }

    public static void ShowAssets(GameObject prefab, GameObject eventUI)
    {
        _statTitle.text = "Активы";
        _statTexts.SetActive(false);
        _statLiabilities.SetActive(false);
        _statSciences.SetActive(false);
        _statTargets.SetActive(false);
        _statAssets.SetActive(true);
        DestroyElements(_statAssets);

        foreach (var asset in Assets)
        {
            var pref = Instantiate(prefab, _statAssets.transform);
            pref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asset.Title;
            pref.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text
                = $"{Converter.ConvertToString(asset.Price.ToString())}" +
                  $"({Converter.ConvertToString(asset.CurrentPrice.ToString())})";

            var btn = pref.GetComponent<Button>();
            btn.onClick.AddListener(() => ShowByAsset(prefab, asset, eventUI));
        }
    }

    private static void DestroyElements(GameObject item)
    {
        foreach (Transform child in item.transform)
            Destroy(child.gameObject);
    }

    private static void ShowByAsset(GameObject prefab, Asset asset, GameObject eventUI)
    {
        eventUI.SetActive(true);
        var title = eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var info = eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var success = eventUI.transform.GetChild(2).GetComponent<Button>();
        var cancel = eventUI.transform.GetChild(3).GetComponent<Button>();

        title.text = asset.Title;
        info.text = $"У вас есть имущество под названием: {asset.Title}\n\n" +
                    $"Вы приобрели имущество за: {Converter.ConvertToString(asset.Price.ToString())}р.\n" +
                    $"Текущая цена имущества: {Converter.ConvertToString(asset.CurrentPrice.ToString())}р.\n" +
                    $"Ежемесячный доход: {Converter.ConvertToString(asset.IncomeValue.ToString())}р.\n" +
                    $"Требуется времени: {Converter.ConvertToString(asset.NeedsTime.ToString())} в месяц\n" +
                    $"Вы хотите продать имущество за: {Converter.ConvertToString(asset.CurrentPrice.ToString())}р?";

        success.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
        success.onClick.AddListener(() => Success(prefab, asset, eventUI));
        cancel.onClick.AddListener(() => Cancel(eventUI));
    }

    private static void Cancel(GameObject eventUI) =>
        eventUI.SetActive(false);

    private static void Success(GameObject prefab, Asset asset, GameObject eventUI)
    {
        Assets.Remove(asset);
        Cash += asset.CurrentPrice;
        eventUI.SetActive(false);
        ShowAssets(prefab, eventUI);

        NeedsUpdate = true;
    }

    public static void ShowLiabilities(GameObject buttonPrefab, GameObject eventUI)
    {
        _statTitle.text = "Пассивы";
        _statAssets.SetActive(false);
        _statTexts.SetActive(false);
        _statSciences.SetActive(false);
        _statTargets.SetActive(false);
        _statLiabilities.SetActive(true);
        DestroyElements(_statLiabilities);

        foreach (var liabilities in Liabilities)
        {
            var pref = Instantiate(buttonPrefab, _statLiabilities.transform);
            pref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = liabilities.Title;
            pref.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text
                = $"{Converter.ConvertToString(liabilities.Price.ToString())}";

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
        info.text = $"У вас есть пассив под названием: {liability.Title}\n\n" +
                    $"Пассив обходится вам в: {Converter.ConvertToString(liability.IncomeValue.ToString())}";

        success.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
        success.onClick.AddListener(() => Cancel(eventUI));
        cancel.onClick.AddListener(() => Cancel(eventUI));
    }

    public static void ShowSciences(GameObject buttonPrefab, GameObject eventUI)
    {
        _statTitle.text = "Знания";
        _statAssets.SetActive(false);
        _statTexts.SetActive(false);
        _statLiabilities.SetActive(false);
        _statTargets.SetActive(false);
        _statSciences.SetActive(true);
        DestroyElements(_statSciences);

        foreach (var education in Educations.Where(educ => educ.ExpirationDate <= 0))
        {
            var pref = Instantiate(buttonPrefab, _statSciences.transform);
            pref.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = education.Title;
            pref.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text
                = $"{Converter.ConvertToString(education.Price.ToString())}";

            var btn = pref.GetComponent<Button>();
            btn.onClick.AddListener(() => ShowByScience(education, eventUI));
        }
    }

    private static void ShowByScience(Education education, GameObject eventUI)
    {
        eventUI.SetActive(true);
        var title = eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        var info = eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var success = eventUI.transform.GetChild(2).GetComponent<Button>();
        var cancel = eventUI.transform.GetChild(3).GetComponent<Button>();

        title.text = education.Title;
        info.text = $"Вы прошли обучающий курс: {education.Title}\n\n" +
                    $"Стоимость курса: {Converter.ConvertToString(education.Price.ToString())}\n" +
                    $"Курс дал прирост к активам в размере: {education.RatioOfUpgrade}%";

        success.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
        success.onClick.AddListener(() => Cancel(eventUI));
        cancel.onClick.AddListener(() => Cancel(eventUI));
    }
}