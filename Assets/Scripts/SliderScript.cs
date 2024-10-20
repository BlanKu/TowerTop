using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider _slider;
    public TextMeshProUGUI _textValue;
    public DataScript _dataScript;

    private void Start()
    {
        _slider.value = _dataScript.player.masterVolume;
    }

    private void Update()
    {
        _dataScript.player.masterVolume = _slider.value;
        _textValue.text = math.round(_slider.value*100).ToString()+"%";
    }
}
