using ClosedXML.Excel;
using HungryPig.Helpers;
using HungryPig.Shared;

namespace HungryPig.Services
{
    public interface IExportService
    {
        byte[] ExportGameDataToExcel(Game game);
    }

    public class ExportService : IExportService
    {
        #region (non)symbolic

        public byte[] ExportGameDataToExcel(Game game)
        {
            var workbook = new XLWorkbook();
            workbook.Properties.Title = $"Data {game.Name} {game.Date:g}";
            workbook.Properties.Subject = $"Data {game.Name} {game.Date:g}";

            CreateWorksheetForGame(workbook, game);

            return ConvertToByte(workbook);
        }

        private void CreateWorksheetForGame(XLWorkbook workbook, Game game)
        {
            var pigMode = game.Mode == Mode.Pig;
            var worksheet = workbook.AddWorksheet("data");
            var columns = new List<string>() { "Volgorde", "Antwoord", "Correct", "Reactie tijd" };

            if (pigMode)
                columns.Insert(1, "Subetized");

            //Columns
            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = columns[i];
            }

            //Extra info
            worksheet.Cell(1, columns.Count + 2).Value = "Naam";
            worksheet.Cell(2, columns.Count + 2).Value = game.Name;
            worksheet.Cell(1, columns.Count + 3).Value = "Datum";
            worksheet.Cell(2, columns.Count + 3).Value = game.Date;

            //Data
            AddLevelData(worksheet, pigMode, game.TutorialLevel1, 2);
            AddLevelData(worksheet, pigMode, game.TutorialLevel2, 3);
            for (int i = 0; i < game.Levels.Count; i++)
            {
                AddLevelData(worksheet, pigMode, game.Levels[i], i + 4);
            }
        }

        private void AddLevelData(IXLWorksheet worksheet, bool pigMode, Level level, int row)
        {
            int column = 1;
            AddDataColumn(worksheet, level.Name, row, ref column);
            if (pigMode)
                AddDataColumn(worksheet, level.Subetizing, row, ref column);
            AddDataColumn(worksheet, level.SideSelected.Description(), row, ref column);
            AddDataColumn(worksheet, level.Correct, row, ref column);
            AddDataColumn(worksheet, level.ReactionTime, row, ref column);
        }

        #endregion

        private void AddDataColumn(IXLWorksheet worksheet, object data, int row, ref int column)
        {
            worksheet.Cell(row, column).Value = data;
            column++;
        }

        private byte[] ConvertToByte(XLWorkbook workbook)
        {
            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();
            return content;
        }
    }
}
