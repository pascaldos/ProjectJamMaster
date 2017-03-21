using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
{
    public Instruments Name;
    public InstrumentType Type;
    public float OverallImportance;
    public float SoloImportance;

    void Start()
    {
        if (Type == InstrumentType.Rythm)
        {
            OverallImportance = 85;
            SoloImportance = 2;
        }

        if (Type == InstrumentType.Harmony)
        {
            OverallImportance = 75;
            SoloImportance = 8;
        }

        if (Type == InstrumentType.Melody)
        {
            OverallImportance = 65;
            SoloImportance = 90;
        }

        Settings.instance.UsedInstruments.Add(this);
    }
}
