using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    UIDocument ui;


    public VisualTreeAsset SettingsTreeAsset;


    private VisualElement _menuElement;
    private VisualElement _settingsElement;



    private Button _playButton;
    private Button _settingsButton;
    private Button _exitButton;



    private void Awake()
    {
        ui = GetComponent<UIDocument>();

        _playButton = ui.rootVisualElement.Q<Button>("Play");
        //_settingsButton = ui.rootVisualElement.Q<Button>("SettingsButton");
        //_exitButton = ui.rootVisualElement.Q<Button>("ExitButton");


        _playButton.clicked += OnPlayClicked;
        //_exitButton.clicked += OnExitClicked;
        //_settingsButton.clicked += OnSettingsClicked;


        _menuElement = ui.rootVisualElement.Q<VisualElement>("StartElement");

        _settingsElement = SettingsTreeAsset.CloneTree();
        //var backButton = _settingsElement.Q<Button>("BackButton");
        //backButton.clicked += OnBackClicked;



    }

    private void OnPlayClicked()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("main");
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }

    private void OnSettingsClicked()
    {
        _menuElement.Clear();
        _menuElement.Add(_settingsElement);

    }

    private void OnBackClicked()
    {
        _menuElement.Clear();
        _menuElement.Add(_playButton);
        //_menuElement.Add(_settingsButton);
        //_menuElement.Add(_exitButton);

    }
}
