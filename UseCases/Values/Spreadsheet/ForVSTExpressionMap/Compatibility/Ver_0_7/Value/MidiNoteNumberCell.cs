using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ArticulationUtility.UseCases.Values.Spreadsheet.ForVSTExpressionMap.Compatibility.Ver_0_7.Value
{
    public class MidiNoteNumberCell : IEquatable<MidiNoteNumberCell>
    {
        /// <summary>
        /// A list containing the index and scale name of the list in sequential form.
        /// These values is used as selectable at a Spreadsheet editor.
        /// </summary>
        private static readonly List<string> NoteNameList;

        /// <summary>
        /// A list containing the index number as string format in sequential form.
        /// These values is used as selectable at s Spreadsheet editor.
        /// </summary>
        private static readonly List<string> NoteNumberList;

        public static List<string> GetNoteNameList()
        {
            return new List<string>( NoteNameList );
        }

        public static List<string> GetNoteNumberList()
        {
            return new List<string>( NoteNumberList );
        }

        static MidiNoteNumberCell()
        {
            #region Mapper
            NoteNameList = new List<string>
            {
                "C-2 (0)",
                "C#-2 (1)",
                "D-2 (2)",
                "D#-2 (3)",
                "E-2 (4)",
                "F-2 (5)",
                "F#-2 (6)",
                "G-2 (7)",
                "G#-2 (8)",
                "A-2 (9)",
                "A#-2 (10)",
                "B-2 (11)",
                "C-1 (12)",
                "C#-1 (13)",
                "D-1 (14)",
                "D#-1 (15)",
                "E-1 (16)",
                "F-1 (17)",
                "F#-1 (18)",
                "G-1 (19)",
                "G#-1 (20)",
                "A-1 (21)",
                "A#-1 (22)",
                "B-1 (23)",
                "C0 (24)",
                "C#0 (25)",
                "D0 (26)",
                "D#0 (27)",
                "E0 (28)",
                "F0 (29)",
                "F#0 (30)",
                "G0 (31)",
                "G#0 (32)",
                "A0 (33)",
                "A#0 (34)",
                "B0 (35)",
                "C1 (36)",
                "C#1 (37)",
                "D1 (38)",
                "D#1 (39)",
                "E1 (40)",
                "F1 (41)",
                "F#1 (42)",
                "G1 (43)",
                "G#1 (44)",
                "A1 (45)",
                "A#1 (46)",
                "B1 (47)",
                "C2 (48)",
                "C#2 (49)",
                "D2 (50)",
                "D#2 (51)",
                "E2 (52)",
                "F2 (53)",
                "F#2 (54)",
                "G2 (55)",
                "G#2 (56)",
                "A2 (57)",
                "A#2 (58)",
                "B2 (59)",
                "C3 (60)",
                "C#3 (61)",
                "D3 (62)",
                "D#3 (63)",
                "E3 (64)",
                "F3 (65)",
                "F#3 (66)",
                "G3 (67)",
                "G#3 (68)",
                "A3 (69)",
                "A#3 (70)",
                "B3 (71)",
                "C4 (72)",
                "C#4 (73)",
                "D4 (74)",
                "D#4 (75)",
                "E4 (76)",
                "F4 (77)",
                "F#4 (78)",
                "G4 (79)",
                "G#4 (80)",
                "A4 (81)",
                "A#4 (82)",
                "B4 (83)",
                "C5 (84)",
                "C#5 (85)",
                "D5 (86)",
                "D#5 (87)",
                "E5 (88)",
                "F5 (89)",
                "F#5 (90)",
                "G5 (91)",
                "G#5 (92)",
                "A5 (93)",
                "A#5 (94)",
                "B5 (95)",
                "C6 (96)",
                "C#6 (97)",
                "D6 (98)",
                "D#6 (99)",
                "E6 (100)",
                "F6 (101)",
                "F#6 (102)",
                "G6 (103)",
                "G#6 (104)",
                "A6 (105)",
                "A#6 (106)",
                "B6 (107)",
                "C7 (108)",
                "C#7 (109)",
                "D7 (110)",
                "D#7 (111)",
                "E7 (112)",
                "F7 (113)",
                "F#7 (114)",
                "G7 (115)",
                "G#7 (116)",
                "A7 (117)",
                "A#7 (118)",
                "B7 (119)",
                "C8 (120)",
                "C#8 (121)",
                "D8 (122)",
                "D#8 (123)",
                "E8 (124)",
                "F8 (125)",
                "F#8 (126)",
                "G8 (127)"
            };

            const int minValue = 0x00;
            const int maxValue = 0x7F;

            NoteNumberList = new List<string>();
            for( int i = minValue; i <= maxValue; i++ )
            {
                NoteNumberList.Add( i.ToString() );
            }
            #endregion
        }

        public string Value { get; }

        public MidiNoteNumberCell( string noteName )
        {
            var found1 = NoteNameList.Contains( noteName );
            var found2 = NoteNumberList.Contains( noteName );

            if( !found1 && !found2 )
            {
                throw new ArgumentException( nameof( noteName ) );
            }

            Value = noteName;
        }

        public bool Equals( [AllowNull] MidiNoteNumberCell other )
        {
            return other != null && other.Value == Value;
        }

        public override string ToString() => Value;
    }
}