/*
	Quickie - predictive rapid text entry engine
	Copyright (C) 2004 Aidan Fitzpatrick

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
using System;

namespace LothianProductions.Quickie {

	public class CharacterGrouping {

		// FIXME These could be replaced by some sort of dynamically configurable
		// mechanism if required.
		public static CharacterGrouping GroupingAbc = new CharacterGrouping( new char[] { 'A', 'B', 'C' } );
		public static CharacterGrouping GroupingDef = new CharacterGrouping( new char[] { 'D', 'E', 'F' } );
		public static CharacterGrouping GroupingGhi = new CharacterGrouping( new char[] { 'G', 'H', 'I' } );
		public static CharacterGrouping GroupingJkl = new CharacterGrouping( new char[] { 'J', 'K', 'L' } );
		public static CharacterGrouping GroupingMno = new CharacterGrouping( new char[] { 'M', 'N', 'O' } );
		public static CharacterGrouping GroupingPqrs = new CharacterGrouping( new char[] { 'P', 'Q', 'R', 'S' } );
		public static CharacterGrouping GroupingTuv = new CharacterGrouping( new char[] { 'T', 'U', 'V' } );
		public static CharacterGrouping GroupingWxyz = new CharacterGrouping( new char[] { 'W', 'X', 'Y', 'Z' } );
		public static CharacterGrouping GroupingSymbol = new CharacterGrouping( new char[] { ' ', '!', '£', '.' } );

		protected char[] mChars;

		protected CharacterGrouping( char[] chars ) {
			mChars = chars;
		}

		// Safer to expose these methods rather than the
		// underlying array at this stage.

		public char this[ int index ] {
			get{ return mChars[ index ]; }
		}

		public int IndexOf( char entry ) {
			return Array.IndexOf( mChars, entry );
		}

		public int Length {
			get{ return mChars.Length; }
		}

		public override string ToString() {
			return new String( mChars );
		}

	}

}
