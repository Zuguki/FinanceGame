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
        private Button _lowBusinessButton, _middleBusinessButton, _heightBusinessButton, _backButton;

        private void Awake()
        {
            SetAssetsUI();
            SetBusinessUI();
        }

        private void SetAssetsUI()
        {
            _assetsTitle = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _realtyButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _businessButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _businessUI = cellUI.transform.GetChild(4).gameObject;

            _realty = _realtyButton.GetComponentInChildren<TextMeshProUGUI>();
            _business = _businessButton.GetComponentInChildren<TextMeshProUGUI>();
            _cancel = _cancelButton.GetComponentInChildren<TextMeshProUGUI>();

            _realtyButton.onClick.RemoveAllListeners();
            _realtyButton.onClick.AddListener(ShowRealty);
            
            _businessButton.onClick.RemoveAllListeners();
            _businessButton.onClick.AddListener(ShowBusiness);

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
            _lowBusinessButton.onClick.AddListener(ShowLowBusiness);

            _middleBusinessButton.onClick.RemoveAllListeners();
            _middleBusinessButton.onClick.AddListener(ShowMiddleBusiness);

            _heightBusinessButton.onClick.RemoveAllListeners();
            _heightBusinessButton.onClick.AddListener(ShowHeightBusiness);

            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(Back);
        }

        private void ShowLowBusiness()
        {
            Debug.Log("Low Business");
        }

        private void ShowMiddleBusiness()
        {
            Debug.Log("Middle Business");
        }

        private void ShowHeightBusiness()
        {
            Debug.Log("Height Business");
        }

        private void Back()
        {
            _businessUI.SetActive(false);
        }

        public void ShowDetails()
        {
            _assetsTitle.text = "Предложенные варианты:";

            cellUI.SetActive(true);
        }

        private void ShowRealty()
        {
        }
        
        private void ShowBusiness()
        {
            _businessUI.SetActive(true);
        }
        
        private void Cancel()
        {
            cellUI.SetActive(false);
        }
    }
}