using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationships
{
    private Dictionary<GameManager.EFactionName, GameManager.EFactionRelation> FactionRelationship
    {
        get; set;
    }
    
    public Relationships(GameManager.EFactionRelation relationType)
    {
        Dictionary<GameManager.EFactionName, GameManager.EFactionRelation> relationships = new Dictionary<GameManager.EFactionName, GameManager.EFactionRelation>();

        foreach (GameManager.EFactionName faction in System.Enum.GetValues(typeof(GameManager.EFactionName)))
        {
            relationships[faction] = relationType;
        }

        FactionRelationship = relationships;
    }
}
