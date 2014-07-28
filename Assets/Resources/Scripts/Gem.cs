using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gem : MonoBehaviour 
{
	public List <Gem> neighbors = new List<Gem>();
	string[] gemMats = {"r", "g", "b", "p", "o", "y" };
	public string color = "";
	public GameObject GemMat;
	public bool isSelected = false;
	public GameObject selector;
	public bool isMatched = false;


	public int XCoord
	{
		get
		{
			return Mathf.RoundToInt(transform.localPosition.x);
		}
	}

	public int YCoord
	{
		get
		{
			return Mathf.RoundToInt(transform.localPosition.y);
		}
	}

	void Start () {
	
		CreateGem ();

	}

	void Update () {
	
	}

	public void ToggleSelector()
	{
		isSelected = !isSelected;
		selector.SetActive (isSelected);
	}

	public void CreateGem()
	{
		color = gemMats[Random.Range(0, gemMats.Length)];
		Material m = Resources.Load ("Materials/" + color)as Material;
		GemMat.renderer.material = m;
		isMatched = false;
	}

	public void AddNeighbor(Gem g)
	{
		if (!neighbors.Contains (g)) 
		{
			neighbors.Add(g);				
		}

	}

	public bool IsNeighborWith(Gem g)
	{
		if (neighbors.Contains (g))
		{
			return true;
		}
		return false;
	}

	public void RemoveNeighbor(Gem g)
	{
		neighbors.Remove(g);
	}


	void OnMouseDown()
	{
		if (GameObject.Find ("Board").GetComponent<Board> ().DetermineBoardState())
						return;
		if(!GameObject.Find("Board").GetComponent<Board>().isSwapping)
		{
			ToggleSelector();
			GameObject.Find("Board").GetComponent<Board>().SwappGems(this);
		}
	}
}
