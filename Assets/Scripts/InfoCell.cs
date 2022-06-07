using System.Collections.Generic;
using System.Linq;
using Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Science
{
    public class InfoCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;

        private static List<Asset> _assetsForInfo;
        private static List<Passive> _passivesForInfo;

        private TextMeshProUGUI _title;
        private TextMeshProUGUI _info;
        private Button _button;

        private int _assetID;
        private int _passiveID;

        private void Awake()
        {
            _title = cellUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _info = cellUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _button = cellUI.transform.GetChild(2).GetComponent<Button>();
        }

        public void ShowDetails()
        {
            SetPlayerStats();
            SetDoneAssets();
            SetDonePassives();
            TryUpgradeMood();
            _assetID = 0;
            _passiveID = 0;

            if (_assetsForInfo.Count > 0)
                ShowAssetUI(_assetID);
            else if (_passivesForInfo.Count > 0)
                ShowPassiveUI(_passiveID);
            else
                Success();

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(Success);
        }

        private void ShowPassiveUI(int passiveID)
        {
            _title.text = "Информация";
            _info.text = $"Вы успешно завершили испытание '{_passivesForInfo[passiveID].Title}'";
            cellUI.SetActive(true);
        }

        private void ShowAssetUI(int assetID)
        {
            _title.text = "Информация";
            _info.text = $"Вы успешно завершили испытание '{_assetsForInfo[assetID].Title}'";
            cellUI.SetActive(true);
        }

        private static void TryUpgradeMood()
        {
            foreach (var _ in Player.Assets.Where(asset => asset.HealthValue > 0))
                Player.Mood += Random.Range(0, 100) > 80 ? 1 : 0;
        }

        private static void SetDoneAssets() =>
            _assetsForInfo = Player.Assets.Where(asset => asset.ExpirationDate == 0).ToList();

        private static void SetDonePassives() =>
            _passivesForInfo = Player.Liabilities.Where(passive => passive.ExpirationDate == 0).ToList();

        private static void SetPlayerStats()
        {
            Player.Cash += Player.CashFlow;
            var assets = new List<Asset>();
            var passives = new List<Passive>();

            foreach (var asset in Player.Assets)
            {
                asset.ExpirationDate--;
                assets.Add(asset);
            }

            foreach (var passive in Player.Liabilities)
            {
                passive.ExpirationDate--;
                passives.Add(passive);
            }

            Player.Assets = new List<Asset>();
            Player.Assets = assets.Select(asset => asset).ToList();

            Player.Liabilities = new List<Passive>();
            Player.Liabilities = passives.Select(passive => passive).ToList();
        }

        private void Success()
        {
            if (++_assetID < _assetsForInfo.Count)
                ShowAssetUI(_assetID);
            else if (++_passiveID < _passivesForInfo.Count)
                ShowPassiveUI(_passiveID);
            else
            {
                cellUI.SetActive(false);
                PlayerMove.CanMove = true;
                CameraMovement.CanMove = true;
                Player.NeedsUpdate = true;
            }
        }
    }
}