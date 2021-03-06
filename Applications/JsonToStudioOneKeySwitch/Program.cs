﻿using ArticulationUtility.Controllers;
using ArticulationUtility.Controllers.Converting;
using ArticulationUtility.FileAccessors.Json.Articulation;
using ArticulationUtility.FileAccessors.StudioOneKeySwitch;
using ArticulationUtility.Interactors.Converting.StudioOneKeySwitch.FromJson;
using ArticulationUtility.Presenters;
using ArticulationUtility.UseCases.Converting;

using ConvertingAppLauncher;

namespace JsonToStudioOneKeySwitch
{
    public class Program : ICliApplication
    {
        public IConvertingFileFormatController GetController( IFileConvertingRequest request )
        {
            var presenter = new ConsoleTextPresenter();
            var loadRepository = new JsonFileRepository();
            var saveRepository = new KeySwitchFileRepository();
            var useCase = new ConvertingToStudioOneKeySwitchFileInteractor( loadRepository, saveRepository, presenter );

            return new ConvertingFileFormatController( useCase );
        }

        public static void Main( string[] args )
        {
            var launcher = new CliAppLauncher( args );
            launcher.Execute( new Program() );
        }
    }
}