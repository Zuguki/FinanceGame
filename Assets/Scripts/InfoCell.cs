using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace
{
    public class InfoCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        private Button _button;
        private TextMeshProUGUI _buttonText;

        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _button = cellUI.transform.GetChild(2).GetComponent<Button>();
            _buttonText = cellUI.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
            
            _button.onClick.AddListener(Success);
        }

        public void ShowDetails()
        {
            _title.text = Random();
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