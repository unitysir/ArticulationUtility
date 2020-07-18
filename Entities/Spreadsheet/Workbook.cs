using System.Collections.Generic;

namespace ArticulationUtility.Entities.Spreadsheet
{
    public class Workbook
    {
        public string Path { get; } = string.Empty;
        public readonly List<Worksheet> Worksheets = new List<Worksheet>();

        public Workbook( string path = null )
        {
            Path = path ?? string.Empty;
        }
    }
}