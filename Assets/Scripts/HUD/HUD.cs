using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Kill, Time, Health}
    public InfoType type;

    Text myText;
    Slider mySlider;
    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Kill:
                myText.text = string.Format("Kills: {0}", GameManager.instance.kills);
                break;
            case InfoType.Time:
                myText.text = string.Format("Time: {0:F2}", GameManager.instance.gameTime); // 수정된 부분
                break;
            case InfoType.Health:
                float curHelth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHelth/maxHealth;
                break;
        }
    }
}
