﻿using ArticulationUtility.Controllers;
using ArticulationUtility.FileAccessors.Spreadsheet;
using ArticulationUtility.FileAccessors.Tsv;
using ArticulationUtility.Interactors.Converting.Tsv.FromSpreadsheet;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace SpreadsheetToTsv
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var (loadRepository, tsvTranslator) = SpreadsheetVersionDetector.DetectRepositoryWithTsv( request.InputFile );
            var saveRepository = new TsvFileRepository();
            var useCase = new ConvertingToTsvInteractor( loadRepository, saveRepository, tsvTranslator );

            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}