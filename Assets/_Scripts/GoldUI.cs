using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _entity;

    void Start()
    {
        _text.text = "Gold : " + _entity._gold.ToString();

        _entity.OnGoldChanged += UpdateGoldUI;
    }

    private void UpdateGoldUI(int newGoldAmount)
    {
        _text.text = "Gold : " + newGoldAmount.ToString();
    }

    private void OnDestroy()
    {
        _entity.OnGoldChanged -= UpdateGoldUI;
    }
}

