using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        private Button _backButton;

        private void Awake()
        {
            SetAssetsUI();
            SetBusinessUI();
            SetRealtyUI();
        }

        private void SetAssetsUI()
        {
            _assetsTitle = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _realtyButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _businessButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _businessUI = cellUI.transform.GetChild(4).gameObject;
            _realtyUI = cellUI.transform.GetChild(5).gameObject;

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

        private void ShowRealty(Realty realty)
        {
            switch (realty)
            {
                case Realty.Low:
                    Debug.Log("Low Realty");
                    break;
                case Realty.Middle:
                    Debug.Log("Middle Realty");
                    break;
                case Realty.Height:
                    Debug.Log("Height Realty");
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
                    Debug.Log("Low business");
                    break;
                case Business.Middle:
                    Debug.Log("Middle business");
                    break;
                case Business.Height:
                    Debug.Log("Height business");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(business), business, null);
            }
        }

        private void Back()
        {
            _businessUI.SetActive(false);
            _realtyUI.SetActive(false);
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