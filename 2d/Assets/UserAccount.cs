using UnityEngine;
using System.Collections;
using System;
[System.Serializable]
public class UserAccounts {
	
	public UserAccounts (string matricNumber, string password, string firstName, string lastName, string loginDateTime, string facebook)
	{
		this.MatricNumber = matricNumber;
		this.Password = password;
		this.FirstName = firstName;
		this.LastName = lastName;
		this.LoginDateTime = loginDateTime;
		this.Facebook = facebook;
	}
	
	public string MatricNumber;
	public string Password;
	public string FirstName;
	public string LastName;
	public string LoginDateTime;
	public string Facebook;

	public string getMatricNumber(){
		return MatricNumber;
	}

	public string getPassword(){
		return Password;
	}

	public string getFirstName(){
		return FirstName;
	}

	public string getLastName(){
		return LastName;
	}

	public string getLoginDateTime(){
		return LoginDateTime;
	}

	public string getFacebook(){
		return Facebook;
	}

	public void setMatricNumber(string MatricNumber){
		this.MatricNumber =  MatricNumber;
	}

	public void setPassword(string Password){
		this.Password = Password;
	}

	public void setFirstName(string FirstName){
		this.FirstName = FirstName;
	}

	public void setLastName(string LastName){
		this.LastName = LastName;
	}

	public void setLoginDateTime(string LoginDateTime){
		this.LoginDateTime = LoginDateTime;
	}

	public void setFacebook(string Facebook){
		this.Facebook = Facebook;
	}
}
