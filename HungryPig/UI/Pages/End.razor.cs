using BlazorDownloadFile;
using Fluxor;
using HungryPig.Services;
using HungryPig.Store.GameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages
{
    partial class End
    {
        [Inject] private IState<GameState> GameState { get; set; }
        [Inject] private IBlazorDownloadFileService DownloadFileService { get; set; }
        [Inject] private IExportService ExportService { get; set; }   

        private async Task DownloadClicked()
        {
            var game = GameState.Value.Game;
            var bytes = ExportService.ExportGameDataToExcel(game);

            await DownloadFileService.ClearBuffers();
            await DownloadFileService.AddBuffer(bytes);
            await DownloadFileService.DownloadFile($"Data {game.Name} {game.Date:g}", bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
