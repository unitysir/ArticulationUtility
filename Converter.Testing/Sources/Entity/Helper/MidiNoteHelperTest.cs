using NUnit.Framework;

using Spreadsheet2Expressionmap.Converter.Entity.Helper;
using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Testing.Entity.Helper
{
    [TestFixture]
    public class MidiNoteHelperTest
    {
        [Test]
        public void NullTest()
        {
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.FromNoteName( null ) );
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.FromNoteName( "" ) );
            Assert.Throws<MidiNoteNotFoundException>( () => MidiNoteHelper.ToNoteName( null ) );
        }


        [Test]
        [TestCase( "C-1 (12)" )]
        [TestCase( "C1 (36)" )]
        [TestCase( "C-1" )]
        [TestCase( "C1" )]
        public void CreateTest( string noteName )
        {
            MidiNoteHelper.FromNoteName( noteName );
        }

    }
}