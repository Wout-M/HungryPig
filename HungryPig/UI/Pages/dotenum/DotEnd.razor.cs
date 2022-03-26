using BlazorDownloadFile;
using Fluxor;
using HungryPig.Services;
using HungryPig.Store.DotGameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages.dotenum
{
    partial class DotEnd
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<DotGameState> GameState { get; set; }
        [Inject] private IBlazorDownloadFileService DownloadFileService { get; set; }
        [Inject] private IExportService ExportService { get; set; }

        private async Task DownloadClicked()
        {
            var game = GameState.Value.Game;
            var bytes = ExportService.ExportDotGameDataToExcel(game);

            await DownloadFileService.ClearBuffers();
            await DownloadFileService.AddBuffer(bytes);
            await DownloadFileService.DownloadFile($"Data {game.Name} {game.Date:g}.xlsx", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private void RestartClicked()
        {
            NavigationManager.NavigateTo("");
        }
    }
}
