﻿using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace DefaultNamespace
{
    public class HealthyCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        
        private Button _successButton;
        private Button _cancelButton;
        
        private TextMeshProUGUI _successButtonText;
        private TextMeshProUGUI _cancelButtonText;

        private IHealthInfo[] _healthInfos;
        private IHealthInfo _healthInfo;
        private int _price;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
            _successButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _successButtonText = cellUI.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();

            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
            _cancelButtonText = cellUI.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void ShowDetails()
        {
            SetHealthInfo();
            _title.text = _healthInfo.Title();
            _info.text = _healthInfo.Details(_price);
                        
            _successButton.onClick.RemoveAllListeners();
            _successButton.onClick.AddListener(Success);
            
            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Cancel);

            cellUI.SetActive(true);
        }

        private void SetHealthInfo()
        {
            var rnd = new Random();

            var percent = rnd.Next(1, 5) * 0.01;
            _healthInfo = _healthInfos[rnd.Next(0, _healthInfos.Length - 1)];
            _price = (int) (percent * Player.Cash);
        }

        private void Success()
        {
            Player.Assets.Add(new Asset(_healthInfo.Title(), _price, 0, 1, 0, -1));
            cellUI.SetActive(false);
        }

        private void Cancel() => cellUI.SetActive(false);
    }
}