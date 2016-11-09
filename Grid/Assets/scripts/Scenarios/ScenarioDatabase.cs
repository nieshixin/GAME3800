using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ScenarioDatabase : MonoBehaviour {
	//Hashtables to store scenario descriptions for each tile
	public static Hashtable descriptionsDB = new Hashtable();

	//List to store specific scenario description text
	public static List<string> IVdescription = new List<string>();

	// Text info in IV description
	static string text1 = " You walked in the dining hall and see a bunch of dead food.";
	static string text2 = " Luckily there isnt any dead fellow NEU students.";
	static string text3 = " Actually, there isnt any person in here at all. ";
	static string text4 = " You found a pizza that is still alive. 'save my daughter, her future is still bright.' ";
	static string text5 = " You choise to save his daugter. Then you eat her. ";

	// Initialize scenario database
	public static void initScenarioDB()
	{
		// Initialize IV description
		IVdescription.Add(text1);
		IVdescription.Add(text2);
		IVdescription.Add(text3);
		IVdescription.Add(text4);
		IVdescription.Add(text5);

		// Initialize Hashtables 
		addScenario(IVdescription);
	}

	/**
     * Adds a new scenario description to description Hashtable
     */
	public static void addScenario(List<string> des)
	{
		descriptionsDB.Add("IV", des);
	}

	public static List<string> getDescription(string tag)
	{
		if (descriptionsDB.ContainsKey(tag)) 
		{
			object hash_value = descriptionsDB[tag];
			if (hash_value is List<string>)
			{
				return (List<string>)hash_value;
			}
		}
		return null;
		
	}

}
