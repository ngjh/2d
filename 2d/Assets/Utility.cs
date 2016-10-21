using UnityEngine;
using System.Collections;
using System.Text;
public class Utility {
	const string URL= "http://redforgegames.com/user1/api.php/";
	private Utility(){
	}
	public static T getFromAPI<T>(string data){
		T jsonObject = default(T);
		WWW jsonData = new WWW (URL + typeof(T).FullName + "/" + data);

		while (!jsonData.isDone) {
			if (jsonData.error == null)
				continue;
			else
				break;
		}

		//Debug.Log (URL + typeof(T).FullName + "/" + data);
		//Debug.Log (jsonData.text);
		if (jsonData.error == null)
			jsonObject = JsonUtility.FromJson<T> (jsonData.text);
		else
			Debug.Log ("Null");
		//Debug.Log (URL + typeof(T).FullName + "/" + data);
		return jsonObject;
	}

	public static bool postToAPI<T>(T data){
		WWWForm form = new WWWForm ();
		//Hashtable headers = form.headers;
		//headers ["Content-Type"] = "application/json";


		string json = JsonUtility.ToJson (data);
		byte[] bytes = Encoding.UTF8.GetBytes (json);
		WWW jsonData = new WWW (URL + typeof(T).FullName, bytes);

		while (!jsonData.isDone) {
			if (jsonData.error == null)
				continue;
			else
				break;
		}
		if (jsonData.error == null)
			return true;
		else
			return false;
	}
}