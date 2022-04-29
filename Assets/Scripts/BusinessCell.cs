using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BusinessCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;

        private Button _businessButton;
        private Button _realtyButton;
        private Button _stocksButton;
        private Button _cancelButton;

        private TextMeshProUGUI _business;
        private TextMeshProUGUI _realty;
        private TextMeshProUGUI _stocks;
        private TextMeshProUGUI _cancel;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _businessButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _realtyButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _stocksButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(4).GetComponent<Button>();

            _business = _businessButton.GetComponentInChildren<TextMeshProUGUI>();
            _realty = _realtyButton.GetComponentInChildren<TextMeshProUGUI>();
            _stocks = _stocksButton.GetComponentInChildren<TextMeshProUGUI>();
            _cancel = _cancelButton.GetComponentInChildren<TextMeshProUGUI>();
            
            _cancelButton.onClick.AddListener(Success);
        }
        
        public void ShowDetails()
        {
            _title.text = "Выбери";
            
            cellUI.SetActive(true);
        }
        
        
        private void Success()
        {
            cellUI.SetActive(false);
        }
    }
}