using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI offbeatText;
    [SerializeField] private TextMeshProUGUI comboPoints;
    public static GameUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
    }

    public void UpdateOffBeatText(float offbeat)
    {
        if (Mathf.Abs(offbeat) >= 0.1f)
        {
            offbeatText.color = Color.red;
            offbeatText.text = $"{offbeat:f1} s";
        }
        else
        {
            offbeatText.color = Color.green;
            offbeatText.text = $"{offbeat:f1} s";
        }
    }
}
