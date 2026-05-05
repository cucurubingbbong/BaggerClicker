using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI swordNameText;
    [SerializeField] private TextMeshProUGUI chanceText;
    [SerializeField] private TextMeshProUGUI ticketText;
    [SerializeField] private Image swordImage;

    public void Refresh(int money, int ticketCount, SwordData swordData)
    {
        moneyText.text = money.ToString();
        priceText.text = $"강화비용:{swordData.upgradePrice:N0}원\n판매가격:{swordData.sellPrice:N0}원";
        swordNameText.text = $"+{swordData.upgradeLevel} {swordData.swordName}";
        chanceText.text = $"성공률 {swordData.chance}%";
        ticketText.text = $"방지권: {ticketCount}";
        swordImage.sprite = swordData.swordSprite;
    }
}
