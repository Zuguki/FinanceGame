using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StudyCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;

        private Button _higherEducationButton;
        private Button _seminarButton;
        private Button _cancelButton;

        private TextMeshProUGUI _higherEducation;
        private TextMeshProUGUI _seminar;
        private TextMeshProUGUI _cancel;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            _higherEducationButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _seminarButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();

            _higherEducation = _higherEducationButton.GetComponentInChildren<TextMeshProUGUI>();
            _seminar = _seminarButton.GetComponentInChildren<TextMeshProUGUI>();
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