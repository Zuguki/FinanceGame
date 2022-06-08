using System.Collections.Generic;
using System.Linq;
using Main;
using Science.HeightEducation;
using Science.Seminars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Science
{
    public class StudyCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;

        private Button _higherEducationButton, _seminarButton, _hideButton;

        private GameObject _eventUI;
        private Button _successButton, _cancelButton, _backButton;
        private TextMeshProUGUI _title, _description;

        private readonly IStudyCell _defaultHeightEducation = new DefaultHeightEducation();

        private readonly IStudyCell[] _cells = {new Managment()};

        private readonly IStudyCell _defaultSeminar = new DefaultSeminar();

        private void Awake()
        {
            _higherEducationButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _seminarButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _hideButton = cellUI.transform.GetChild(3).GetComponent<Button>();

            _eventUI = cellUI.transform.GetChild(5).gameObject;
            _title = _eventUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            _description = _eventUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            _successButton = _eventUI.transform.GetChild(2).GetComponent<Button>();
            _cancelButton = _eventUI.transform.GetChild(3).GetComponent<Button>();
            _backButton = _eventUI.transform.GetChild(4).GetComponent<Button>();

            RemoveListenersFromButtons();
            SetMethodsToButtons();
        }

        private void RemoveListenersFromButtons()
        {
            _higherEducationButton.onClick.RemoveAllListeners();
            _seminarButton.onClick.RemoveAllListeners();
            _hideButton.onClick.RemoveAllListeners();
            _successButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }

        private void SetMethodsToButtons()
        {
            _higherEducationButton.onClick.AddListener(() => ShowChoice(StudyTrack.HigherEducation));
            _seminarButton.onClick.AddListener(() => ShowChoice(StudyTrack.Seminar));
            _hideButton.onClick.AddListener(Cancel);
        }

        private void ShowChoice(StudyTrack studyTrack)
        {
            var listOfTracks = _cells.Where(cell => cell.Track == studyTrack
                                                    && Player.Educations.All(educ => educ.Title != cell.Title))
                .ToList();

            var asset = GetAssetByTrack(studyTrack, listOfTracks);

            _eventUI.SetActive(true);
            _title.text = asset.Title;
            _description.text = asset.Description;

            RemoveListenersFromButtons();
            SetMethodsToButtons();
            _successButton.onClick.AddListener(() => Success(asset));
            _cancelButton.onClick.AddListener(Cancel);
            _backButton.onClick.AddListener(Cancel);
        }

        private IStudyCell GetAssetByTrack(StudyTrack studyTrack, IReadOnlyList<IStudyCell> listOfTracks)
        {
            if (listOfTracks.Count == 0)
                return studyTrack is StudyTrack.HigherEducation ? _defaultHeightEducation : _defaultSeminar;

            return listOfTracks[Random.Range(0, listOfTracks.Count)];
        }

        public void ShowDetails() => cellUI.SetActive(true);

        private void Success(IStudyCell asset)
        {
            // TODO: Добавить кредиты
            if (Player.Cash < asset.Price || asset == _defaultHeightEducation || asset == _defaultSeminar)
            {
                Cancel();
                return;
            }

            Player.Cash -= asset.Price;
            Player.Educations.Add(
                new Education(asset.Title, asset.Description, asset.Price, asset.ExpirationDate,
                    asset.NeedsTime, asset.RatioOfUpgrade, asset.Track));

            Player.NeedsUpdate = true;
            Cancel();
        }

        private void Cancel()
        {
            _eventUI.SetActive(false);
            cellUI.SetActive(false);
            CameraMovement.CanMove = true;
        }
    }
}