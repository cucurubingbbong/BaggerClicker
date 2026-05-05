using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private SwordData[] swordDatas;
    [SerializeField] private UpgradeUI upgradeUI;
    [SerializeField] private int money;
    [SerializeField] private int currentUpgradeLevel;
    [SerializeField] private int preventTicketCount;
    [SerializeField] private int preventTicketPrice;

    private void Start()
    {
        RefreshUI();
    }

    public void UpgradeSword()
    {
        SwordData swordData = swordDatas[currentUpgradeLevel];

        if (money < swordData.upgradePrice)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }

        money -= swordData.upgradePrice;

        int randomValue = Random.Range(0, 100);
        bool isSuccess = randomValue < swordData.chance;

        if (isSuccess)
        {
            if (currentUpgradeLevel < swordDatas.Length - 1)
            {
                currentUpgradeLevel++;
            }

            Debug.Log("강화 성공");
        }
        else
        {
            if (preventTicketCount > 0)
            {
                preventTicketCount--;
                Debug.Log("방지권 사용");
            }
            else
            {
                currentUpgradeLevel = 0;
                Debug.Log("강화 실패");
            }
        }

        RefreshUI();
    }

    public void SellSword()
    {
        SwordData swordData = swordDatas[currentUpgradeLevel];

        money += swordData.sellPrice;
        currentUpgradeLevel = 0;

        Debug.Log("판매 완료");
        RefreshUI();
    }

    public void BuyPreventTicket()
    {
        if (money < preventTicketPrice)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }

        money -= preventTicketPrice;
        preventTicketCount++;

        Debug.Log("방지권 구매");
        RefreshUI();
    }

    private void RefreshUI()
    {
        upgradeUI.Refresh(money, preventTicketCount, swordDatas[currentUpgradeLevel]);
    }
}
