using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboText : MonoBehaviour
{
    public TextMeshPro text;

    public void SetCombo(int combo)
    {
        text.text = combo.ToString();
    }
}
