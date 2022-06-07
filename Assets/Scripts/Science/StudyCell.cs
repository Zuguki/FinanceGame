using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StudyCell : MonoBehaviour, ICell
    {
        [SerializeField] private GameObject cellUI;
        
        private Button _higherEducationButton, _seminarButton, _hideButton;

        private GameObject _eventUI;
        private Button _successButton, _cancelButton, _backButton;
        private TextMeshProUGUI _title, _description;

        private readonly IStudyCell _defaultHeightEducation;

        private readonly IStudyCell[] _cells = { };
        
        private readonly IStudyCell _defaultSeminar;

        private void Awake()
        {
            _higherEducationButton = cellUI.transform.GetChild(1).GetComponent<Button>();
            _seminarButton = cellUI.transform.GetChild(2).GetComponent<Button>();
            _hideButton = cellUI.transform.GetChild(3).GetComponent<Button>();

            _eventUI = cellUI.transform.GetChild(4).gameObject;
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
                                                    && Player.Assets.All(asset => asset.Title != cell.Title))
                .ToList();

            var asset = GetAssetByTrack(studyTrack, listOfTracks);
            
            _eventUI.SetActive(true);
            _title.text = asset.Title;
            _description.text = asset.Description;
            
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

        public void ShowDetails()
        {
            cellUI.SetActive(true);
        }
        
        private void Success(IStudyCell asset)
        {
            if (asset == _defaultHeightEducation && asset == _defaultSeminar)
            {
                Cancel();
                return;
            }

            Player.Assets.Add(
                new Asset(asset.Title, asset.Price, 0, -1, asset.ExpirationDate, asset.NeedsTime));
            
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