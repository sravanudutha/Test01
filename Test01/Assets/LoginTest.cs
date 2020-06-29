using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;

public class LoginTest : MonoBehaviour
{

    public InputField email, pswd;
    // Start is called before the first frame update
    void Start()
    {
       var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        //OnlyforEmailSignup();
    }

    Firebase.Auth.FirebaseAuth auth;

    public void OnlyforEmailSignup()                         //use this function on Register button to sign in without phone authentication script..saves us from building apk to test
    {

        var auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.CreateUserWithEmailAndPasswordAsync(email.text, pswd.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            
            //MessagePanel.SetActive(true);

            //StartCoroutine(MessageTimer());
            //SceneManager.LoadScene("Login");

        });

        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Debug.Log("in Loop");


           var  Patient_UId = user.UserId;
            Debug.Log(Patient_UId);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
