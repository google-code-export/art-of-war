﻿using System;
using UnityEngine;

/// <summary>
/// Game state representing main menu view.
/// </summary>
public class MainMenuState : GameState
{
    private MainMenuUI ui;

    /// <summary>
    /// Gets level scene name associated with main menu.
    /// </summary>
    public override string LevelName
    {
        get { return "IntroIslandScene"; }
    }

    public MainMenuState(GameController controller, GameState previous) : base(controller, previous) { }

    /// <summary>
    /// State enter event. Initializes state internal variables and prepares view elements.
    /// </summary>
    public override void Enter()
    {
        base.Enter();
        GameManager manager = GameManager.Instance();
        ui = manager.GameUIInstance.MainMenuUIInstance;
        AttachEventHandlers();
        ui.Show();
    }

    /// <summary>
    /// State exit event. Hides view elements.
    /// </summary>
    public override void Exit()
    {
        ui.Hide();
        DetachEventHandlers();
        base.Exit();
    }

    #region Event Handlers
    private void AttachEventHandlers()
    {
        ui.StartButton.ButtonClicked += StartButtonClickedHandler;
        ui.ScoreButton.ButtonClicked += HighScoresButtonClickedHandler;
        ui.HelpButton.ButtonClicked += HelpButtonClickedHandler;
        ui.ExitButton.ButtonClicked += ExitButtonClickedHandler;
    }

    private void DetachEventHandlers()
    {
        ui.ExitButton.ButtonClicked -= ExitButtonClickedHandler;
        ui.HelpButton.ButtonClicked -= HelpButtonClickedHandler;
        ui.ScoreButton.ButtonClicked -= HighScoresButtonClickedHandler;
        ui.StartButton.ButtonClicked -= StartButtonClickedHandler;
    }

    private void StartButtonClickedHandler(object sender, EventArgs args)
    {
        Debug.Log("Start button clicked");
        parent.GoToInGameState();
    }

    private void HighScoresButtonClickedHandler(object sender, EventArgs args)
    {
        Debug.Log("High Scores button clicked");
    }

    private void HelpButtonClickedHandler(object sender, EventArgs args)
    {
        Debug.Log("Help button clicked");
        parent.GoToHelpState();
    }

    private void ExitButtonClickedHandler(object sender, EventArgs args)
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }
    #endregion
}
