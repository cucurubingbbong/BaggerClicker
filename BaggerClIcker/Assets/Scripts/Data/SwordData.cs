using UnityEngine;

[CreateAssetMenu(fileName = "SwordData", menuName = "GameData/SwordData", order = 1)]
public class SwordData : ScriptableObject
{
    // 검 이름
    public string swordName;

    // 강화 레벨
    public int upgradeLevel;

    // 강화 비용
    public int upgradePrice;

    // 판매 가격
    public int sellPrice;

    // 강화 성공 확률
    public int chance;

    // 검 이미지
    public Sprite swordSprite;
}
