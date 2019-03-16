using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    private List<int> modifers = new List<int>();

    public int GetValue()
    {
        return baseValue;
    }

    public void AddModifer(int modifier)
    {
        if (modifier !=0)
        {
            modifers.Add(modifier);
        }
    }

    public void RemoveModifer(int modifer)
    {
        if(modifer!= 0)
        {
            modifers.Remove(modifer);
        }
    }
	
}
