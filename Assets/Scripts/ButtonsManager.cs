using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject eventUI;
    
    private Button _main, _assets, _liabilities, _sciences, _targets;

    private void Awake()
    {
        _main = transform.GetChild(0).GetComponent<Button>();
        _assets = transform.GetChild(1).GetComponent<Button>();
        _liabilities = transform.GetChild(2).GetComponent<Button>();
        _sciences = transform.GetChild(3).GetComponent<Button>();
        _targets = transform.GetChild(4).GetComponent<Button>();
        
        _main.onClick.AddListener(Player.ShowMain);
        _assets.onClick.AddListener(() => Player.ShowAssets(buttonPrefab, eventUI));
        _liabilities.onClick.AddListener(() => Player.ShowLiabilities(buttonPrefab, eventUI));
        _sciences.onClick.AddListener(() => Player.ShowSciences(buttonPrefab, eventUI));
        _targets.onClick.AddListener(() => Player.ShowTargets(textPrefab));
    }
}
