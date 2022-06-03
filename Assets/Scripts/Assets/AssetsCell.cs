using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class AssetsCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;

        private TextMeshProUGUI _assetsTitle;
        private Button _businessButton, _realtyButton, _cancelButton;
        private TextMeshProUGUI _realty, _business, _cancel;

        private GameObject _businessUI;
        private Button _lowBusinessButton, _middleBusinessButton, _heightBusinessButton;

        private GameObject _realtyUI;
        private Button _lowRealtyButton, _middleRealtyButton, _heightRealtyButton;

        private GameObject _choiceUI;
        private Button _acceptButton, _rejectButton;
        private TextMeshProUGUI _choiceTitle, _choiceDetails;

        private Button _backButton;

        private IBusinessInfo[] _businessInfos = { new Pivovarnya() };

        private IRealtyInfo[] _realtyInfos = { };

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
            _businessUI = cellUI.transform.GetChild(4).gameObject;
            _realtyUI = cellUI.transform.GetChild(5).gameObject;
            _choiceUI = cellUI.transform.GetChild(6).gameObject;

            _realty = _realtyButton.GetComponentInChildren<TextMeshProUGUI>();
            _business = _businessButton.GetComponentInChildren<TextMeshProUGUI>();
            _cancel = _cancelButton.GetComponentInChildren<TextMeshProUGUI>();

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
            _lowBusinessButton.onClick.AddListener(() => ShowBusiness(Business.Low));

            _middleBusinessButton.onClick.RemoveAllListeners();
            _middleBusinessButton.onClick.AddListener(() => ShowBusiness(Business.Middle));

            _heightBusinessButton.onClick.RemoveAllListeners();
            _heightBusinessButton.onClick.AddListener(() => ShowBusiness(Business.Height));

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
            _lowRealtyButton.onClick.AddListener(() => ShowRealty(Realty.Low));
            
            _middleRealtyButton.onClick.RemoveAllListeners();
            _middleRealtyButton.onClick.AddListener(() => ShowRealty(Realty.Middle));
            
            _heightRealtyButton.onClick.RemoveAllListeners();
            _heightRealtyButton.onClick.AddListener(() => ShowRealty(Realty.Height));
            
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
        }

        private void ShowRealty(Realty realty)
        {
            switch (realty)
            {
                case Realty.Low:
                    ShowChoice(realty: realty);
                    break;
                case Realty.Middle:
                    Debug.Log("Middle Realty");
                    break;
                case Realty.Height:
                    Debug.Log("Height Realty");
                    break;
                case Realty.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(realty), realty, null);
            }
        }

        private void ShowBusiness(Business business)
        {
            switch (business)
            {
                case Business.Low:
                    ShowChoice(Business.Low);
                    break;
                case Business.Middle:
                    Debug.Log("Middle business");
                    break;
                case Business.Height:
                    Debug.Log("Height business");
                    break;
                case Business.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(business), business, null);
            }
        }

        private void ShowChoice(Business business = Business.None, Realty realty = Realty.None)
        {
            if (business is not Business.None)
            {
                var currentList = _businessInfos.Where(bus => bus.BusinessInfo == business).ToList();
                var currentItem = currentList[Random.Range(0, currentList.Count)];
                
                _choiceTitle.text = currentItem.Title;
                _choiceDetails.text = currentItem.Details;
                
                _acceptButton.onClick.RemoveAllListeners();
                _acceptButton.onClick.AddListener(() => ShowChoiceByBusiness(currentItem));
            }
            else if (realty is not Realty.None)
            {
                var currentList = _realtyInfos.Where(rea => rea.RealtyInfo == realty).ToList();
                var currentItem = currentList[Random.Range(0, currentList.Count)];

                _choiceTitle.text = currentItem.Title;
                _choiceDetails.text = currentItem.Details;
                
                _acceptButton.onClick.RemoveAllListeners();
                _acceptButton.onClick.AddListener(() => ShowChoiceByRealty(currentItem));
            }
        }

        private void ShowChoiceByRealty(IRealtyInfo currentItem)
        {
            // TODO: Добавить кредиты
            if (Player.Cash < currentItem.Price)
            {
                Cancel();
                return;
            }

            Player.Assets.Add(new Asset(currentItem.Title, currentItem.Price, currentItem.Income, 0, -1,
                currentItem.NeedsTime));
            Player.Cash -= currentItem.Price;
            Player.NeedsUpdate = true;
        }

        private void ShowChoiceByBusiness(IBusinessInfo currentItem)
        {
            // TODO: Добавить кредиты
            if (Player.Cash < currentItem.Price)
            {
                Cancel();
                return;
            }
            // TODO: Проверить с отрицательными значениями
            Player.Assets.Add(new Asset(currentItem.Title, currentItem.Price, currentItem.Income, 0, -1,
                currentItem.NeedsTime));
            Player.Cash -= currentItem.Price;
            Player.NeedsUpdate = true;
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

        private void ShowRealtyUI()
        {
            _realtyUI.SetActive(true);
        }
        
        private void ShowBusinessUI()
        {
            _businessUI.SetActive(true);
        }
        
        private void Cancel()
        {
            cellUI.SetActive(false);
        }
    }
}