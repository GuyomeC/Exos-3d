using System;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    public int _gold;
    public event Action<int> OnGoldChanged; // �v�nement pour notifier les changements d'or

    void Awake()
    {
        _gold = 0;
    }

    public void AddGold(int goldToAdd)
    {
        _gold += goldToAdd;
        OnGoldChanged?.Invoke(_gold); // D�clenche l'�v�nement � chaque changement
    }
}
