using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VersionScript : MonoBehaviour
{
    public TextMeshProUGUI _VersionText;
    private void Start()
    {
        _VersionText.text = Application.version.ToString();
    }
}
