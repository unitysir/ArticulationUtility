using System.Collections.Generic;
using System.IO;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.MidiEvent.Value;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;
using ArticulationUtility.Utilities;

using Articulation = ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate.Articulation;
using ArticulationJson = ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap.Articulation;
using OutputMappingJson = ArticulationUtility.UseCases.Values.Json.ForVSTExpressionMap.OutputMapping;

namespace ArticulationUtility.Adapters.VSTExpressionMap.FromJson
{
    public class JsonAdapter : IExpressionMapAdapter<JsonRoot>
    {
        public List<ExpressionMap> Convert( JsonRoot source )
        {
            var expressionMap = new ExpressionMap( new ExpressionMapName( source.Name ) );
            var idGenerator = new ArticulationIdGenerator();

            foreach( var obj in source.Articulations )
            {
                // Articulation
                var articulationId = idGenerator.Next();
                var articulation = ParseArticulation( obj, articulationId );

                // SoundSlot
                var soundSlot = ParseSoundSlot( obj, articulationId );

                expressionMap.Articulations.Add( articulationId, articulation );
                expressionMap.SoundSlots.Add( soundSlot );
            }

            var result = new List<ExpressionMap> { expressionMap };

            return result;
        }

        private static Articulation ParseArticulation( ArticulationJson obj, ArticulationId articulationId )
        {
            var articulationName = new ArticulationName( obj.Name );
            var articulationType = EnumHelper.Parse<ArticulationType>( obj.Type, ArticulationType.Default );
            var articulationGroup = new ArticulationGroup( obj.Group );
            var articulation = new Articulation( articulationId, articulationName, articulationType, articulationGroup );

            return articulation;
        }

        private static SoundSlot ParseSoundSlot( ArticulationJson obj, ArticulationId articulationId )
        {
            var soundSlot = new SoundSlot( new SoundSlotName( obj.Name ), new SoundSlotColorIndex( obj.Color ) );
            soundSlot.ReferenceArticulationIds.Add( articulationId );

            foreach( var midi in obj.OutputMapping )
            {
                IMidiEvent mapping;

                switch( midi.Status )
                {
                    case ArticulationJson.MidiNoteOn:
                        var noteName = new MidiNoteName( midi.Data1 );
                        var velocity = int.Parse( midi.Data2 );
                        mapping = new MidiNoteOn( noteName.ToMidiNoteNumber(), new MidiVelocity( velocity ) );
                        break;

                    case ArticulationJson.ControlChange:
                        var ccNumber = int.Parse( midi.Data1 );
                        var ccValue = int.Parse( midi.Data2 );
                        mapping = new MidiControlChange( new MidiControlChangeNumber( ccNumber ), new MidiControlChangeValue( ccValue ) );
                        break;

                    case ArticulationJson.Program:
                        var programValue = int.Parse( midi.Data1 );
                        mapping = new ProgramEvent( new ProgramEventValue( programValue ) );
                        break;

                    default:
                        var status = new MidiStatusCode( int.Parse( midi.Status ) );
                        var data1 = new GenericMidiEventValue( int.Parse( midi.Data1 ) );
                        var data2 = new GenericMidiEventValue( int.Parse( midi.Data2 ) );
                        mapping = new GenericMidiEvent( status, data1, data2 );
                        break;
                };

                soundSlot.OutputMappings.Add( mapping );
            }

            return soundSlot;
        }
    }
}