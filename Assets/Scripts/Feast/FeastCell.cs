using System.Linq;
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

        private IFeastInfo _feast = new Default();
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
            SetFeastInfo();
            _title.text = _feast.Title();
            _info.text = _feast.Details(Converter.ConvertToString(_price.ToString()));

            _successButton.onClick.RemoveAllListeners();
            
            var graphic = _successButton.GetComponent<Graphic>();
            if (Player.Cash < _price)
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

        private void SetFeastInfo()
        {
            var rnd = new Random();

            if (Player.Mood > 5)
            {
                var percent = rnd.Next(5, 15) * 0.01;
                var feastsCount = _feasts.Count(info => info.IsLiabilities() is false);
                if (feastsCount == 0)
                {
                    _feast = new Default();
                    return;
                }

                _feast = _feasts.Where(info => info.IsLiabilities() is false).ToList()[rnd.Next(0, feastsCount - 1)];
                if (Player.Cash < 100_000 || (int) (percent * Player.Cash) < 50_000)
                    _price = 100_000;
                else
                    _price = (int) (percent * Player.Cash);
            }
            else
            {
                var percent = rnd.Next(5, 10) * 0.01;
                var feastsCount = _feasts.Count(info => info.IsLiabilities() 
                                                        && !Player.Liabilities.Any(liab => liab.Title == info.Title()));
                if (feastsCount == 0)
                {
                    _feast = new Default();
                    return;
                }

                _feast = _feasts.Where(info => info.IsLiabilities() 
                                               && !Player.Liabilities.Any(liab => liab.Title == info.Title()))
                    .ToList()[rnd.Next(0, feastsCount - 1)];
                
                if (Player.Cash < 100_000 || (int) (percent * Player.Cash) < 50_000)
                    _price = 100_000;
                else
                    _price = (int) (percent * Player.Cash);

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