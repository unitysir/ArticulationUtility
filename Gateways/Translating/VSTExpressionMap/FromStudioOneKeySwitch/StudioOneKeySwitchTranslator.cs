using System.Collections.Generic;

using ArticulationUtility.Entities.MidiEvent.Aggregate;
using ArticulationUtility.Entities.MidiEvent.Value;
using ArticulationUtility.Entities.StudioOneKeySwitch.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Aggregate;
using ArticulationUtility.Entities.VSTExpressionMap.Value;

namespace ArticulationUtility.Gateways.Translating.VSTExpressionMap.FromStudioOneKeySwitch
{
    public class StudioOneKeySwitchTranslator : IDataTranslator<KeySwitch, List<ExpressionMap>>
    {
        public List<ExpressionMap> Translate( KeySwitch source )
        {
            var name = new ExpressionMapName( source.Name.Value );
            var articulations = new Dictionary<ArticulationId, Articulation>();
            var soundSlots = new List<SoundSlot>();

            var idGenerator = new ArticulationIdGenerator();

            foreach( var element in source.KeySwitchList )
            {
                // Articulation
                var articulationId = idGenerator.Next();
                var articulation = ParseArticulation( element, articulationId );
                articulations.Add( articulationId, articulation );

                // SoundSlot
                var soundSlot = ParseSoundSlot( element, articulationId );
                soundSlots.Add( soundSlot );
            }

            // Aggregate Expressionmap
            var expressionMap = new ExpressionMap(
                name,
                articulations,
                soundSlots
            );

            return  new List<ExpressionMap> { expressionMap };
        }

        private static Articulation ParseArticulation( KeySwitchElement obj, ArticulationId articulationId )
        {
            var articulationName = new ArticulationName( obj.Name.Value );
            var articulationType = ArticulationType.Direction;
            var articulationGroup = new ArticulationGroup( ArticulationGroup.MinValue );
            var articulation = new Articulation( articulationId, articulationName, ArticulationSymbol.None, articulationType, articulationGroup );

            return articulation;
        }

        private static SoundSlot ParseSoundSlot( KeySwitchElement obj, ArticulationId articulationId )
        {
            var soundSlot = new SoundSlot(
                new SoundSlotName( obj.Name.Value ),
                new SoundSlotColorIndex( SoundSlotColorIndex.MinValue )
            );
            soundSlot.ReferenceArticulationIds.Add( articulationId );

            var noteName = new MidiNoteName( obj.KeySwitchPitch.Value.ToString() );
            var velocity = MidiVelocity.MinValue;
            var mapping = new MidiNoteOn( noteName.ToMidiNoteNumber(), new MidiVelocity( velocity ) );

            soundSlot.OutputMappings.Add( mapping );

            return soundSlot;
        }
    }
}