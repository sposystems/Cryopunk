using UnityEngine;
using System.Collections;

public class CreateNewEquipment : MonoBehaviour {

	private BaseEquipment newEquipment;
	private string[] itemNames = new string[4]{"Common", "Great","Amazing", "Insane"};
	private string[] itemDes = new string[2]{"okay item", "wonderful item"};

	void Start () {
		CreateEquipment ();
		Debug.Log (newEquipment.ItemName);
		Debug.Log (newEquipment.ItemDescription);
		Debug.Log (newEquipment.ItemID.ToString());
		Debug.Log (newEquipment.EquipmentType.ToString());
		Debug.Log (newEquipment.Stamina.ToString());
		Debug.Log (newEquipment.Endurance.ToString());
	}

	private void CreateEquipment(){
		newEquipment = new BaseEquipment ();
		newEquipment.ItemName = itemNames [Random.Range (0, 4)];
		newEquipment.ItemID = Random.Range (1, 101);
		ChooseItemType ();
		newEquipment.ItemDescription = itemDes[Random.Range(1,itemDes.Length)];
		newEquipment.Stamina = Random.Range (1, 11);
		newEquipment.Endurance = Random.Range (1, 11);
		newEquipment.Intellect = Random.Range (1, 11);
		newEquipment.Strength = Random.Range (1, 11);

		}
	private void ChooseItemType(){
		int randomTemp = Random.Range (1, 9);
		if (randomTemp == 1) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.HEAD;
		}else if (randomTemp == 2) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.CHEST;
		}else if (randomTemp == 3) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.SHOULDERS;
		}else if (randomTemp == 4) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.EARS;
		}
		else if (randomTemp == 5) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.FEET;
		}
		else if (randomTemp == 6) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.LEGS;
		}
		else if (randomTemp == 7) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.NECK;
		}
		else if (randomTemp == 8) {
			newEquipment.EquipmentType = BaseEquipment.EquipmentTypes.RING;
		}
	}
}
