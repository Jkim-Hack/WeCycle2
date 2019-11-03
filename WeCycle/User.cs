using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{

    private String user_Name;
    public String User_Name
    { 
        get { return this.user_Name; } 
    }
    private String user_password;
    public String User_Password
    {
        get { return this.user_password; }
    }
    private String user_email;
    public String User_Email
    {
        get { return this.user_email; }
    }


    private int user_phoneNumber;
    public int User_PhoneNumber
    { 
        get { return this.user_phoneNumber; } 
    }


    private int user_coinCount;
    public int User_CoinCount
    {
        get { return this.user_coinCount; }
    }

    private int user_num_ChallengeCompleted;
    public int User_Num_ChallengeCompleted
    {
        get { return this.user_num_ChallengeCompleted; }
    }

    public User(String userName,String user_password,String user_email, int user_phoneNumber, int coinCount, int numChallengeCompleted)
	{
        this.user_Name = userName;
        this.user_password = user_password;
        this.user_email = user_email;
        this.user_phoneNumber = user_phoneNumber;
        this.user_coinCount = coinCount;
        this.user_num_ChallengeCompleted = numChallengeCompleted;   
	}

    public override string ToString() 
    {
        return "UserName: " + user_Name + " User Password: " + user_password + " User Email: " + user_email + " User Phone Num: " + user_phoneNumber + " User Coin Count " + user_coinCount + " Number Of Challenges Completed: " + user_num_ChallengeCompleted; 
    }

}
