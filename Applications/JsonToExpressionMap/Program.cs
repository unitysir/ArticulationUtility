﻿using ArticulationUtility.Controllers;
using ArticulationUtility.Controllers.Converting;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.VSTExpressionMapXml;
using ArticulationUtility.Interactors.Converting.VSTExpressionMap.FromJson;
using ArticulationUtility.Presenters;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace JsonToExpressionMap
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var loadRepository = new JsonFileRepository();
            var saveRepository = new ExpressionMapFileRepository();
            var useCase = new ConvertingToExpressionMapFileInteractor( loadRepository, saveRepository );
            var presenter = new ConsoleProgressPresenter();

            return new ConvertingFileFormatController( useCase, presenter );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}