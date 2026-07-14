using TMPro;
using UnityEngine;

[System.Serializable]
public class MeasuringTape
{
    public GameObject TapeLine;
    public TextMeshPro TapeInfo;

    public static double MetersToInches(float meters) => meters * 39.3701;
    public static double MetersToCentimeters(float meters) => meters * 100.0;
}