using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject eventUI;
    
    private Button _main, _assets, _liabilities;

    private void Awake()
    {
        _main = transform.GetChild(0).GetComponent<Button>();
        _assets = transform.GetChild(1).GetComponent<Button>();
        _liabilities = transform.GetChild(2).GetComponent<Button>();
        
        _main.onClick.AddListener(Player.ShowMain);
        _assets.onClick.AddListener(() => Player.ShowAssets(buttonPrefab, eventUI));
        _liabilities.onClick.AddListener(() => Player.ShowLiabilities(buttonPrefab, eventUI));
    }
}
