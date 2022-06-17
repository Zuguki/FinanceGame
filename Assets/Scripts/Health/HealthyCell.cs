using System.Linq;
using Main;
using Science;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Health
{
    public class HealthyCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        
        private Button _successButton;
        private Button _cancelButton;
        
        private readonly IHealthInfo[] _healthInfos =
        {
            new Athletics(), new Fitness(), new GoodFood(), new Gym(), new Massage(), new Ofk(),
            new SwimmingPool(), new Volleyball()
        };
        private IHealthInfo _healthInfo;
        private int _price;
        
        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
            _successButton = cellUI.transform.GetChild(2).GetComponent<Button>();

            _cancelButton = cellUI.transform.GetChild(3).GetComponent<Button>();
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void ShowDetails()
        {
            SetHealthInfo();
            _title.text = _healthInfo.Title();
            _info.text = _healthInfo.Details(_price);
                        
            _successButton.onClick.RemoveAllListeners();
            
            var graphic = _successButton.GetComponent<Graphic>();
            if (Player.Cash < _price || Player.FreeTime < _healthInfo.NeedsTime())
                graphic.color = Player.UnActiveButtonColor;
            else
            {
                _successButton.onClick.AddListener(Success);
                graphic.color = Player.ActiveButtonColor;
            }
            
            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(Cancel);

            cellUI.SetActive(true);
        }

        private void SetHealthInfo()
        {
            var rnd = new Random();

            var percent = rnd.Next(5, 15) * 0.01;
            var goodInfo = _healthInfos
                .Where(info => Player.Assets.All(p => p.Title != info.Title())).ToList();

            if (goodInfo.Count > 0)
            {
                _healthInfo = goodInfo[rnd.Next(0, goodInfo.Count - 1)];
                if (Player.Cash < 100_000 || (int) (percent * Player.Cash) < 50_000)
                    _price = 100_000;
                else
                    _price = (int) (percent * Player.Cash);
            }
            else
                _healthInfo = new DefaultHealth();
            
        }

        private void Success()
        {
            Player.Assets.Add(new Asset
                (_healthInfo.Title(), _price, 0, 1, _healthInfo.ExpirationDate(), _healthInfo.NeedsTime()));
            Player.Cash -= _price;

            cellUI.SetActive(false);
            Player.NeedsUpdate = true;
            CameraMovement.CanMove = true;
        }

        private void Cancel()
        {
            cellUI.SetActive(false);
            Player.NeedsUpdate = true;
            CameraMovement.CanMove = true;
        }
    }
}