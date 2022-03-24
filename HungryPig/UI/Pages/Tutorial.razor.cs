﻿using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using HungryPig.Store.GameUseCase.Actions;
using HungryPig.UI.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HungryPig.UI.Pages
{
    partial class Tutorial
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<GameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private Level CurrentTutorialLevel { get; set; }
        private Mode Mode { get; set; }
        private bool NextAllowed { get; set; }
        private Stopwatch Stopwatch { get; set; } = new();

        private TutorialField TutorialFieldLeft { get; set; }
        private TutorialField TutorialFieldRight { get; set; }

        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
            CurrentTutorialLevel = GameState.Value.Game.TutorialLevel1;

            Stopwatch.Start();
        }

        private void SideSelected(bool correct, Side side)
        {
            if (!NextAllowed)
            {
                Stopwatch.Stop();
                var time = Stopwatch.ElapsedMilliseconds;

                CurrentTutorialLevel.SideSelected = side;
                CurrentTutorialLevel.Correct = correct;
                CurrentTutorialLevel.ReactionTime = time;

                bool leftCorrect = correct && side == Side.Left;
                if (!correct && side == Side.Right) leftCorrect = true;

                TutorialFieldLeft?.SetBorderColor(leftCorrect);
                TutorialFieldRight?.SetBorderColor(!leftCorrect);

                Dispatcher.Dispatch(new UpdateTutorialLevelAction(CurrentTutorialLevel, CurrentTutorialLevel.Name == "Oefenitem1"));

                NextAllowed = true;
                StateHasChanged();
            }
        }

        private void NextClicked()
        {
            NextAllowed = false;
            TutorialFieldLeft?.ResetBorderColor();
            TutorialFieldRight?.ResetBorderColor();

            if (CurrentTutorialLevel.Name == "Oefenitem1")
            {
                CurrentTutorialLevel = GameState.Value.Game.TutorialLevel2;
                Stopwatch.Start();
            }
            else
            {
                NavigationManager.NavigateTo("/game");
            }
        }
    }
}
