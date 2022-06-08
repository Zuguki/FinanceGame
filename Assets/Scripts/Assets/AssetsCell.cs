using System.Collections.Generic;
using System.Linq;
using Assets.Business;
using Assets.Realty;
using Main;
using Science;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets
{
    public class AssetsCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;

        private TextMeshProUGUI _assetsTitle;
        private Button _businessButton, _realtyButton, _cancelButton;

        private GameObject _businessUI;
        private Button _lowBusinessButton, _middleBusinessButton, _heightBusinessButton;

        private GameObject _realtyUI;
        private Button _lowRealtyButton, _middleRealtyButton, _heightRealtyButton;

        private GameObject _choiceUI;
        private Button _acceptButton, _rejectButton;
        private TextMeshProUGUI _choiceTitle, _choiceDetails;

        private Button _backButton;

        private readonly IAsset _defaultBusiness = new DefaultBusinessNotification();

        private readonly IAsset[] _assetInfos = { new Pivovarnya(), new Home() };

        private readonly IAsset _defaultRealty = new DefaultRealtyNotification();

        private void Awake()
        {
            SetAssetsUI();
            SetBusinessUI();
            SetRealtyUI();
            SetChoiceUI();
        }

        private void SetAssetsUI()
        {
            _assetsTitle = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _realtyButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _businessButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _businessUI = cellUI.transform.GetChild(5).gameObject;
            _realtyUI = cellUI.transform.GetChild(6).gameObject;
            _choiceUI = cellUI.transform.GetChild(7).gameObject;

            _realtyButton.onClick.RemoveAllListeners();
            _realtyButton.onClick.AddListener(ShowRealtyUI);
            
            _businessButton.onClick.RemoveAllListeners();
            _businessButton.onClick.AddListener(ShowBusinessUI);

            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Cancel);
        }

        private void SetBusinessUI()
        {
            _lowBusinessButton = _businessUI.transform.GetChild(1).GetComponent<Button>();
            _middleBusinessButton = _businessUI.transform.GetChild(2).GetComponent<Button>();
            _heightBusinessButton = _businessUI.transform.GetChild(3).GetComponent<Button>();
            _backButton = _businessUI.transform.GetChild(4).GetComponent<Button>();

            _lowBusinessButton.onClick.RemoveAllListeners();
            _lowBusinessButton.onClick.AddListener(() => ShowChoice(Business.Business.Low));

            _middleBusinessButton.onClick.RemoveAllListeners();
            _middleBusinessButton.onClick.AddListener(() => ShowChoice(Business.Business.Middle));

            _heightBusinessButton.onClick.RemoveAllListeners();
            _heightBusinessButton.onClick.AddListener(() => ShowChoice(Business.Business.Height));

            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(Back);
        }

        private void SetRealtyUI()
        {
            _lowRealtyButton = _realtyUI.transform.GetChild(1).GetComponent<Button>();
            _middleRealtyButton = _realtyUI.transform.GetChild(2).GetComponent<Button>();
            _heightRealtyButton = _realtyUI.transform.GetChild(3).GetComponent<Button>();
            _backButton = _realtyUI.transform.GetChild(4).GetComponent<Button>();
            
            _lowRealtyButton.onClick.RemoveAllListeners();
            _lowRealtyButton.onClick.AddListener(() => ShowChoice(realty: Realty.Realty.Low));
            
            _middleRealtyButton.onClick.RemoveAllListeners();
            _middleRealtyButton.onClick.AddListener(() => ShowChoice(realty: Realty.Realty.Middle));
            
            _heightRealtyButton.onClick.RemoveAllListeners();
            _heightRealtyButton.onClick.AddListener(() => ShowChoice(realty: Realty.Realty.Height));
            
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(Back);
        }

        private void SetChoiceUI()
        {
            _choiceTitle = _choiceUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _choiceDetails = _choiceUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _acceptButton = _choiceUI.transform.GetChild(2).GetComponent<Button>();
            _rejectButton = _choiceUI.transform.GetChild(3).GetComponent<Button>();
            _backButton = _choiceUI.transform.GetChild(4).GetComponent<Button>();
            
            _rejectButton.onClick.RemoveAllListeners();
            _rejectButton.onClick.AddListener(Cancel);
            
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(Back);
        }

        private void ShowChoice(Business.Business business = Business.Business.None,
            Realty.Realty realty = Realty.Realty.None)
        {
            _choiceUI.SetActive(true);

            var currentList = business is not Business.Business.None
                ? _assetInfos.Where(bus => bus.BusinessInfo == business
                                              && Player.Assets.All(asset => asset.Title != bus.Title))
                    .ToList()
                : _assetInfos.Where(rea =>
                        rea.RealtyInfo == realty && Player.Assets.All(asset => asset.Title != rea.Title))
                    .ToList();

            var asset = business is not Business.Business.None
                ? GetItemByAssets(currentList)
                : GetItemByAssets(currentList, false);

            _choiceTitle.text = asset.Title;
            _choiceDetails.text = asset.Details;
                
            _acceptButton.onClick.RemoveAllListeners();
            _acceptButton.onClick.AddListener(() => ShowChoiceByAsset(asset));
        }

        private IAsset GetItemByAssets(IReadOnlyList<IAsset> assets, bool isBusiness = true)
        {
            if (isBusiness)
            {
                return assets.Count == 0
                    ? _defaultBusiness
                    : assets[Random.Range(0, assets.Count)];
            }

            return assets.Count == 0
                ? _defaultRealty
                : assets[Random.Range(0, assets.Count)];
        }

        private void ShowChoiceByAsset(IAsset currentItem)
        {
            // TODO: Добавить кредиты
            if (Player.Cash < currentItem.Price || currentItem == _defaultRealty || currentItem == _defaultBusiness)
            {
                Cancel();
                return;
            }
            
            Player.Assets.Add(new Asset(currentItem.Title, currentItem.Price, currentItem.Income, 0, -1,
                currentItem.NeedsTime));
            Player.Cash -= currentItem.Price;
            Player.NeedsUpdate = true;
            
            Cancel();
        }

        private void Back()
        {
            _businessUI.SetActive(false);
            _realtyUI.SetActive(false);
            _choiceUI.SetActive(false);
        }

        public void ShowDetails()
        {
            _assetsTitle.text = "Предложенные варианты:";

            cellUI.SetActive(true);
        }

        private void ShowRealtyUI() => _realtyUI.SetActive(true);

        private void ShowBusinessUI() => _businessUI.SetActive(true);
        
        private void Cancel()
        {
            cellUI.SetActive(false);
            _businessUI.SetActive(false);
            _realtyUI.SetActive(false);
            _choiceUI.SetActive(false);
            CameraMovement.CanMove = true;
        }
    }
}