using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class AssetsCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;

        private Button _businessButton;
        private Button _realtyButton;
        private Button _cancelButton;

        private TextMeshProUGUI _realty;
        private TextMeshProUGUI _business;
        private TextMeshProUGUI _cancel;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _realtyButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _businessButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();

            _realty = _realtyButton.GetComponentInChildren<TextMeshProUGUI>();
            _business = _businessButton.GetComponentInChildren<TextMeshProUGUI>();
            _cancel = _cancelButton.GetComponentInChildren<TextMeshProUGUI>();
            
            _realtyButton.onClick.RemoveAllListeners();
            _realtyButton.onClick.AddListener(ShowRealty);

            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Cancel);
        }
        
        public void ShowDetails()
        {
            _title.text = "Предложенные варианты:";
            
            cellUI.SetActive(true);
        }

        private void ShowRealty()
        {
            
        }
        
        private void Cancel()
        {
            cellUI.SetActive(false);
        }
    }
}