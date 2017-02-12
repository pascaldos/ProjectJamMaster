using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTestSheet : MonoBehaviour
{
    public GameObject Quad;
    public Color SoloColor;
    public Color BackGroundColor;
    public Color OffColor;
    private Settings Settings;
    public float NodeLength;
    public int TotalNodes;

    private GameObject[,] Grid;

    // Use this for initialization
    public void OnTestSheetCreation(GameObject Panel)
    {
        Panel.SetActive(true);

        Settings = Settings.instance;
        NodeLength = (float)60 / (float)Settings.BPM * (float)Settings.PatternLength * Settings.Tact;
        TotalNodes = (int)(Settings.Length / NodeLength);

        CreateGrid();
    }


    void CreateGrid()
    {
        Grid = new GameObject[TotalNodes, Settings.UsedInstruments.Count];

        for (int x = 0; x < TotalNodes; x++)
        {
            for (int y = 0; y < Settings.UsedInstruments.Count; y++)
            {
                GameObject go = Instantiate(Quad, new Vector3(x, y, 0), Quaternion.identity);
                go.transform.parent = this.transform;
                Grid[x, y] = go;
            }
        }
    }

    void SetIsPlaying()
    {
        for (int y = 0; y < Settings.UsedInstruments.Count; y++)
        {
            float currentImportance = Settings.UsedInstruments[y].OverallImportance;

            for (int x = 0; x < TotalNodes; x++)
            {
                if() Random.Range(0,1)
            }
        }
    }
    void SetSolo()
    {

    }

    void SetVolume()
    {

    }
}
