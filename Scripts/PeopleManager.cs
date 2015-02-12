using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PeopleManager : MonoBehaviour 
{
	private static PeopleManager _instance;	
	public static PeopleManager instance
	{
		get
		{
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<PeopleManager>();
			return _instance;
		}
	}
	public List<Sprite> peopleSprites = new List<Sprite> ();
	public List<GameObject> people = new List<GameObject> ();
	public List<Sprite> goodGuySprites = new List<Sprite> ();
	public GameObject personObject;
	public GameObject badGuyObject;
	public int badGuyIndex;
	public int maxSpawn = 32;

	public float posY;
	public float posX;

	public void SpawnPeople () {
		badGuyIndex = Random.Range (0, peopleSprites.Count - 1);

		goodGuySprites = new List<Sprite> (peopleSprites);
		goodGuySprites.RemoveAt(badGuyIndex);

		for (int i = 0; i < maxSpawn; i++) {
			int randomPerson = Random.Range (0, goodGuySprites.Count - 1);
			Vector3 spawnPosition = new Vector3(Random.Range(-posX, posX), Random.Range(-posY, posY), 0);
			GameObject goodGuyObject = (GameObject)Instantiate(personObject, spawnPosition, Quaternion.identity);
			goodGuyObject.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = goodGuySprites[randomPerson];
			people.Add(goodGuyObject);
		}

		// Spawn Bad Guy
		badGuyObject = (GameObject)Instantiate(personObject, new Vector3(Random.Range(-posX, posX), Random.Range(-posY, posY), 0), Quaternion.identity);
		badGuyObject.transform.GetChild(0).GetComponent<SpriteRenderer> ().sprite = peopleSprites [badGuyIndex];
		people.Add(badGuyObject);

		foreach (GameObject person in people) {
			person.transform.GetChild(0).GetComponent<AutoMover>().offset = Random.Range (0.0f, 1.0f);
		}

	}

}