using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    public GameObject InstrumentsWindow;

    public int BPM;
    public List<Instrument> UsedInstruments = new List<Instrument>();
    public int PatternLength;
    public float Tact;
    public int Length;


    void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void OnInstrumentButtonClicked(GameObject SpawnPrefab)
    {
        GameObject NewInstrument = Instantiate(SpawnPrefab);
        NewInstrument.transform.parent = GameObject.FindObjectOfType<Canvas>().transform;
        NewInstrument.transform.position = new Vector2(200 + 100* UsedInstruments.Count, 150);

        InstrumentsWindow.SetActive(false);
    }

    public void OnAddInstrumentButtonClicked()
    {
        InstrumentsWindow.SetActive(true);
    }

    public void OnInputFieldEditEnd(InputField self)
    {
        char[] delimiterChars = { '/', ':' };

        if (self.transform.name == "Tact")
        {
            string[] words = self.text.Split(delimiterChars);
            int i;
            int j;
            int.TryParse(words[0], out i);
            int.TryParse(words[1], out j);
            Tact = (float)i / (float)j;
        }

        if (self.transform.name == "BPM")
        {
            int.TryParse(self.text, out BPM);
        }

        if (self.transform.name == "PatternLength")
        {
            int.TryParse(self.text, out PatternLength);
        }

        if (self.transform.name == "Length")
        {
            Length = 0;
            int count = 0;
            string[] words = self.text.Split(delimiterChars);
            for (int x = words.Length - 1; x >= 0; x--)
            {
                int i = 0;
                int.TryParse(words[x], out i);
                Length += i * (int)(Mathf.Pow(60, count));
                count++;
            }
        }
    }

}
