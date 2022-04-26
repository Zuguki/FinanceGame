using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace
{
    public class FeastCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        
        private Button _successButton;
        private Button _cancelButton;
        
        private TextMeshProUGUI _successButtonText;
        private TextMeshProUGUI _cancelButtonText;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
            _successButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _successButtonText = cellUI.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();

            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _cancelButtonText = cellUI.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
            
            _successButton.onClick.AddListener(Success);
            _cancelButton.onClick.AddListener(Success);
        }
        
        public void ShowDetails()
        {
            _title.text = "Fest";
            _info.text = Random();
                        
            cellUI.SetActive(true);
        }
        
        
        private void Success()
        {
            cellUI.SetActive(false);
        }

        private string Random()
        {
            var rnd = new Random();
            var result = new StringBuilder();
            
            for (var index = 0; index < 5; index++)
                result.Append(rnd.Next(0, 1000));

            return result.ToString();
        }    
    }
}