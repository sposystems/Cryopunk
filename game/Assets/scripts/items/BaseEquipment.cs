using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEquipment : BaseStatItem {

	public enum EquipmentTypes{
		HEAD,
		CHEST,
		SHOULDERS,
		LEGS,
		FEET,
		NECK,
		RING,
		EARS

	}
	private int spellEffectID;

	private EquipmentTypes equipmentType;
	public EquipmentTypes EquipmentType{
		get{ return equipmentType;}
		set{ equipmentType = value;}
	}

	public int SpellEffectID{
		get{ return spellEffectID;}
		set{ spellEffectID = value;}
	}
}
