using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogComponent : MonoBehaviour
{
    public GameObject DialogUI;
    public Text TextDisplay;
    Dictionary<string, string[]> DialogData = new Dictionary<string, string[]>();

    [SerializeField]
    float typingSpeed;
    string[] dialogs;
    int index;
    bool isType = false;
    Coroutine typeCoroutine;

    public void InitDialogData(DialogueModel [] dialog)
    {
        isType = false;
        DialogUI.SetActive(false);
        for (int i = 0; i < dialog.Length; i++) {
            DialogData.Add(dialog[i].Id, dialog[i].DialogueData);
        }
    }

    public void TypeDialog(string id)
    {
        DialogUI.SetActive(true);
        dialogs = DialogData[id];
        typeCoroutine = StartCoroutine(Type());
    }

    IEnumerator Type() {
        isType = true;
        foreach (char word in dialogs[index].ToCharArray()) {
            TextDisplay.text += word;
            if (TextDisplay.text == dialogs[index])
                isType = false;

            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentences() {
        if (index < dialogs.Length)
        {
            if (isType) {
                TextDisplay.text = dialogs[index];
                isType = false;
                StopCoroutine(typeCoroutine);
            }
            else
            {
                if (index < dialogs.Length - 1)
                {
                    index++;
                    TextDisplay.text = "";
                    Debug.Log("Dialog Next");
                    typeCoroutine = StartCoroutine(Type());
                }
                else
                {
                    TextDisplay.text = "";
                    Debug.Log("Dialog End");
                    DialogUI.SetActive(false);
                }
            }
        }
        else
        {
            TextDisplay.text = "";
            Debug.Log("Dialog End");
            DialogUI.SetActive(false);
        }
    }
}
