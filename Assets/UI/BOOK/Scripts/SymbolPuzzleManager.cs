using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public GameObject[] slot1Symbols;
    public GameObject[] slot2Symbols;
    public GameObject[] slot3Symbols;

    private int slot1Index = 0;
    private int slot2Index = 0;
    private int slot3Index = 0;

    void Start()
    {
        UpdateSlot(slot1Symbols, slot1Index);
        UpdateSlot(slot2Symbols, slot2Index);
        UpdateSlot(slot3Symbols, slot3Index);
    }

    public void Slot1Up()
    {
        slot1Index++;
        if (slot1Index >= slot1Symbols.Length)
            slot1Index = 0;

        UpdateSlot(slot1Symbols, slot1Index);
    }

    public void Slot1Down()
    {
        slot1Index--;
        if (slot1Index < 0)
            slot1Index = slot1Symbols.Length - 1;

        UpdateSlot(slot1Symbols, slot1Index);
    }

    public void Slot2Up()
    {
        slot2Index++;
        if (slot2Index >= slot2Symbols.Length)
            slot2Index = 0;

        UpdateSlot(slot2Symbols, slot2Index);
    }

    public void Slot2Down()
    {
        slot2Index--;
        if (slot2Index < 0)
            slot2Index = slot2Symbols.Length - 1;

        UpdateSlot(slot2Symbols, slot2Index);
    }

    public void Slot3Up()
    {
        slot3Index++;
        if (slot3Index >= slot3Symbols.Length)
            slot3Index = 0;

        UpdateSlot(slot3Symbols, slot3Index);
    }

    public void Slot3Down()
    {
        slot3Index--;
        if (slot3Index < 0)
            slot3Index = slot3Symbols.Length - 1;

        UpdateSlot(slot3Symbols, slot3Index);
    }

    void UpdateSlot(GameObject[] symbols, int activeIndex)
    {
        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].SetActive(i == activeIndex);
        }
    }

    public void ConfirmSymbols()
    {
        if (slot1Index == 0 && slot2Index == 1 && slot3Index == 2)
        {
            Debug.Log("Corect simboluri!");
        }
        else
        {
            Debug.Log("Gresit simboluri!");
        }
    }
}