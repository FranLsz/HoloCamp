using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    private KeywordRecognizer _keywordRecognizer;
    private Dictionary<string, Action> _keywordsDictionary = new Dictionary<string, Action>();

    // Use this for initialization
    void Start()
    {
        _keywordsDictionary.Add("New color", () =>
        {
            var focusedObject = GazeManager.Instance.FocusedObject;
            if (focusedObject != null)
                focusedObject.SendMessage("OnSelect");
        });

        _keywordRecognizer = new KeywordRecognizer(_keywordsDictionary.Keys.ToArray());
        _keywordRecognizer.OnPhraseRecognized += param =>
        {
            Action action;
            if (_keywordsDictionary.TryGetValue(param.text, out action))
                action.Invoke();
        };

        _keywordRecognizer.Start();
    }
}
