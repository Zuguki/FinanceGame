﻿using System.Linq;
using Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Feast
{
    public class FeastCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        
        private Button _successButton;
        private Button _cancelButton;
        
        private readonly IFeastInfo[] _feasts =
        {
            new BlueWindow(), new IllegalRider(), new ImRocker(),
            new ForKebabs(), new HelloAlisa(),
            
            new ShifterMachine(), new MovieMan(), new ElectricScooter(),
            new LovelyHome(), new MusicConnectMe()
        };
        private IFeastInfo _feast;
        private int _price;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
            _successButton = cellUI.transform.GetChild(2).GetComponent<Button>();

            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
        }
        
        public void ShowDetails()
        {
            SetFeastInfo();
            _title.text = _feast.Title();
            _info.text = _feast.Details(_price);
            
            _successButton.onClick.RemoveAllListeners();
            _successButton.onClick.AddListener(Success);
            
            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Cancel);
            
            cellUI.SetActive(true);
        }

        private void SetFeastInfo()
        {
            var rnd = new Random();
            
            if (Player.Mood > 5)
            {
                var percent = rnd.Next(1, 10) * 0.01;
                var feastsCount = _feasts.Count(info => info.IsLiabilities() is false);
                _feast = _feasts.Where(info => info.IsLiabilities() is false).ToList()[rnd.Next(0, feastsCount - 1)];
                _price = (int)(percent * Player.Cash);
            }
            else
            {
                var percent = rnd.Next(1, 5) * 0.01;
                var feastsCount = _feasts.Count(info => info.IsLiabilities());
                _feast = _feasts.Where(info => info.IsLiabilities()).ToList()[rnd.Next(0, feastsCount - 1)];
                _price = (int)(percent * Player.Cash);
            }
        }

        private void Success()
        {
            var rnd = new Random();
            
            if (_feast.IsLiabilities())
            {
                var passive = new Passive(_feast.Title(), _price, _feast.ExpirationDate());
                Player.Liabilities.Add(passive);
            }
            
            Player.Mood += rnd.Next(1, 2);
            Player.Cash -= _price;
            cellUI.SetActive(false);
            Player.NeedsUpdate = true; 
            CameraMovement.CanMove = true;
        }

        private void Cancel()
        {
            var rnd = new Random();

            Player.Mood -= rnd.Next(1, 3);
            cellUI.SetActive(false);
            Player.NeedsUpdate = true;
            CameraMovement.CanMove = true;
        }
    }
}