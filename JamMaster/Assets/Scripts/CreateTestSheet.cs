using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTestSheet : MonoBehaviour
{
    public GameObject Quad;
    public Color SoloColor;
    public Color BackGroundColor;
    public Color OffColor;
    private Settings Setting;
    public float NodeLength;
    public int TotalNodes;

    private GameObject[,] Grid;


    public void OnTestSheetCreation(GameObject Panel)
    {
        Panel.SetActive(true);

        Setting = Settings.instance;
        NodeLength = (float)60 / (float)Setting.BPM * (float)Setting.PatternLength * Setting.Tact;
        TotalNodes = (int)(Setting.Length / NodeLength);

        CreateGrid();
        SetIsPlaying();
        SetSolo();
    }

    void CreateGrid()
    {
        Grid = new GameObject[TotalNodes, Setting.UsedInstruments.Count];

        for (int x = 0; x < TotalNodes; x++)
        {
            for (int y = 0; y < Setting.UsedInstruments.Count; y++)
            {
                GameObject go = Instantiate(Quad, new Vector3(x, y, 0), Quaternion.identity);
                go.transform.parent = this.transform;
                Grid[x, y] = go;
            }
        }
    }

    void SetIsPlaying()
    {
        for (int y = 0; y < Setting.UsedInstruments.Count; y++)
        {
            float currentImportance = Setting.UsedInstruments[y].OverallImportance;
            for (int x = 0; x < TotalNodes; x++)
            {
                if (Random.Range(0, 100) > currentImportance)
                {
                    Grid[x, y].GetComponent<Renderer>().material.color = OffColor;
                }
                else
                {
                    Grid[x, y].GetComponent<Renderer>().material.color = BackGroundColor;
                }
            }
        }
    }
    void SetSolo()
    {
        for (int i = 0; i < TotalNodes; i++)
        {
            float typeValue = 0;
            float harmonyValue = 0;
            float melodyValue = 0;
            float rythmValue = 0;

            foreach (Instrument I in Setting.UsedInstruments)
            {
                if (I.Type == InstrumentType.Harmony)
                {
                    harmonyValue = I.SoloImportance;
                }
                if (I.Type == InstrumentType.Melody)
                {
                    melodyValue = I.SoloImportance;
                }
                if (I.Type == InstrumentType.Rythm)
                {
                    rythmValue = I.SoloImportance;
                }
            }

            typeValue = harmonyValue + melodyValue + rythmValue;

            if (typeValue == 0)
            {
                Debug.LogError("NO INSTRUMENTS");
            }


            int Rnd = Random.Range(0, (int)typeValue);

            List<int> TempList = new List<int>();
            int count = 0;
            int RandomOfType = 0;
            if (Rnd < harmonyValue)
            {
                foreach (Instrument I in Setting.UsedInstruments)
                {
                    if (I.Type == InstrumentType.Harmony)
                    {
                        if (Grid[i, count].GetComponent<Renderer>().material.color != OffColor)
                        {
                            TempList.Add(count);
                        }
                    }
                    count++;
                }

                RandomOfType = Random.Range(0, TempList.Count - 1);
            }
            if (Rnd >= harmonyValue && Rnd < harmonyValue + melodyValue)
            {
                foreach (Instrument I in Setting.UsedInstruments)
                {
                    if (I.Type == InstrumentType.Melody)
                    {
                        if (Grid[i, count].GetComponent<Renderer>().material.color != OffColor)
                        {
                            TempList.Add(count);
                        }
                    }
                    count++;
                }
                RandomOfType = Random.Range(0, TempList.Count - 1);

            }
            if (Rnd > harmonyValue + melodyValue)
            {
                foreach (Instrument I in Setting.UsedInstruments)
                {
                    if (I.Type == InstrumentType.Rythm)
                    {
                        if (Grid[i, count].GetComponent<Renderer>().material.color != OffColor)
                        {
                            TempList.Add(count);
                        }
                    }
                    count++;
                    RandomOfType = Random.Range(0, TempList.Count - 1);
                }
            }

            if(TempList.Count != 0)
            {
                Grid[i, TempList[RandomOfType]].GetComponent<Renderer>().material.color = SoloColor;
            }
        }
    }
    void SetVolume()
    {

    }
}
