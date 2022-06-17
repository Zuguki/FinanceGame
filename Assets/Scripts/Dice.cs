using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    public static bool IsThrows;
    public static int Steps { get; private set; }

    [SerializeField] private GameObject[] uIs;

    private bool _coroutineAllowed = true;
    private Sprite[] _diceSides;
    private Image _renderer;
    private Button _button;

    private const int TwistDice = 10;

    private void Start()
    {
        _renderer = GetComponent<Image>();
        _diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        _renderer.sprite = _diceSides[0];
        _button = GetComponent<Button>();

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(Roll);
    }

    private void Roll()
    {
        if (_coroutineAllowed && uIs.All(ui => !ui.activeSelf))
            StartCoroutine(nameof(RollTheDice));
    }

    private IEnumerator RollTheDice()
    {
        _coroutineAllowed = false;

        for (var twist = 0; twist < TwistDice; twist++)
        {
            Steps = Random.Range(0, 6);
            _renderer.sprite = _diceSides[Steps];
            yield return new WaitForSeconds(0.05f);
        }

        Steps++;
        IsThrows = true;
        _coroutineAllowed = true;
    }
}