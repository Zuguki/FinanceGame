﻿using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class InfoCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;

        private static List<Asset> _assetsForInfo;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        private Button _button;
        private TextMeshProUGUI _buttonText;

        private int _assetID;

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
            SetPlayerStats();
            SetDoneAssets();
            _assetID = 0;
            
            if (_assetsForInfo.Count == 0)
                ShowClearUI();
            else
                ShowUI(_assetID);
            
            cellUI.SetActive(true);
        }

        private void ShowClearUI()
        {
            _title.text = "Info";
            _info.text = "В этом месяце нет каких либо событий";
        }

        private void ShowUI(int assetID)
        {
            _title.text = "Info";
            _info.text = $"Вы успешно завершили курс {_assetsForInfo[assetID].Title}";
        }

        private static void SetDoneAssets() => 
            _assetsForInfo = Player.Assets.Where(asset => asset.ExpirationDate == 0).ToList();

        private static void SetPlayerStats()
        {
            Player.Cash += Player.CashFlow;
            var list = new List<Asset>();
            
            foreach (var asset in Player.Assets)
            {
                asset.ExpirationDate--;
                list.Add(asset);
            }

            Player.Assets = new List<Asset>();
            Player.Assets = list.Select(asset => asset).ToList();
        }

        private void Success()
        {
            if (++_assetID >= _assetsForInfo.Count)
            {
                _assetID = 0;
                Player.NeedsUpdate = true;
                cellUI.SetActive(false);
            }
            else
                ShowUI(_assetID);
        }
    }
}