using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction
{
    private GameManager.EFactionName FactionName
    {
        get; set;
    }

    public Color Color
    {
        get; set;
    }

    public Relationships FactionRelationships
    {
        get; set;
    }

    public Faction(GameManager.EFactionName newName, Color newColor, Relationships newRelationships)
    {
        FactionName = newName;
        Color = newColor;
        FactionRelationships = newRelationships;
    }
}
