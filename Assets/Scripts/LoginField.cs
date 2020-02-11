using UnityEngine;
using UnityEngine.UI;
public class LoginField : MonoBehaviour
{
    InputField inputField;
    [SerializeField]LoginIO login;
    
    void Start()
    {
        inputField = GetComponent<InputField>();
        var submit = new InputField.SubmitEvent();
        submit.AddListener(login.Login);
        inputField.onEndEdit = submit;
    }
}