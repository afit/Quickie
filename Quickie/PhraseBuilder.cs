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
using System.Collections;
using System.Text;

namespace LothianProductions.Quickie {

	public interface PhraseBuilder {

		/// <summary>
		/// Adds a new character to the phrase. If the phrase
		/// suggester can match a potential word, an intelligent
		/// choice of characters from the passed character
		/// grouping will be used, otherwise the first character
		/// in the grouping will be use.
		/// </summary>
		/// <param name="character">The character grouping to choose a new character from.</param>
		void AddCharacter( CharacterGrouping character );

		/// <summary>
		/// Advances the last character entered to the next
		/// character in its character grouping.
		/// i.e. A becomes B becomes C becomes A.
		/// </summary>
		void NextCharacter();

		/// <summary>
		/// Deletes the last character from the phrase. Does
		/// nothing if no characters are available to delete.
		/// </summary>
		void DeleteCharacter();

		/// <summary>
		/// Removes all characters from the phrase.
		/// </summary>
		void Clear();

		/// <summary>
		/// Toggles the alphabet case of the next series
		/// of characters to be entered. The default state
		/// is upper-case.
		/// </summary>
		void ToggleCase();
		
		/// <summary>
		/// Returns the current phrase.
		/// </summary>
		// Expect explicit ToString implementation.
		String ToString();

		/// <summary>
		/// Property controlling access to the underlying
		/// words list used for word prediction.
		/// </summary>
		Hashtable Words {
			get;
			set;
		}

	}

	/// <summary>
	/// Simple implementation of PhraseBuilder.
	/// </summary>
	public class PhraseBuilderImpl : PhraseBuilder {

		// FIXME Not safe for multithreaded access.

		protected StringBuilder mPhrase = new StringBuilder();
		protected IList mGroups = new ArrayList();
		protected bool mUpperCase = true;

		// Default words list:
		protected Hashtable mWords = new WordsXmlProvider().GetWords();

		public void AddCharacter( CharacterGrouping character ) {
			char next = PhraseSuggester.Suggest( mWords, ToString(), character );

			if( ! mUpperCase )
				next = Char.ToLower( next );

			mPhrase.Append( next );
			mGroups.Add( character );
		}

		public void NextCharacter() {
			if( mPhrase.Length < 1 )
				return;

			int lastIndex = mPhrase.Length - 1;

			char last = Char.ToUpper( mPhrase[ lastIndex ] );
			CharacterGrouping lastGroup = (CharacterGrouping) mGroups[ lastIndex ];

			if( lastGroup.IndexOf( last ) < lastGroup.Length - 1 )
				mPhrase[ lastIndex ] = lastGroup[ lastGroup.IndexOf( last ) + 1 ];
			else
				mPhrase[ lastIndex ] = lastGroup[ 0 ];

			if( ! mUpperCase )
				mPhrase[ lastIndex ] = Char.ToLower( mPhrase[ lastIndex ] );
		}

		public void DeleteCharacter() {
			if( mPhrase.Length < 1 )
				return;

			mPhrase.Remove( mPhrase.Length - 1, 1 );
			mGroups.RemoveAt( mGroups.Count - 1 );
		}

		public void Clear() {
			mPhrase = new StringBuilder();
			mGroups.Clear();
		}

		public void ToggleCase() {
			mUpperCase = ! mUpperCase;
		}

		public override String ToString() {
			return mPhrase.ToString();
		}

		public Hashtable Words {
			get{ return mWords; }
			set{ mWords = value; }
		}

	}

	public class PhraseSuggester {

		/// <summary>
		/// Returns the next suggested character from a character grouping
		/// for a given phrase based on a search of the words database
		/// against the last partially formed word in the current phrase.
		/// </summary>
		public static char Suggest( Hashtable words, String phrase, CharacterGrouping next ) {

			SortedList results = new SortedList();

			// This is all highly inefficient, but it's such a tiny
			// search. A TST-backed search could really help here.

			// Another way of improving performance could be to generate
			// the word list on the fly using XLST 

			// The search key must be the last word in the phrase.

			// FIXME Using symbols like this to delimit words is fairly
			// crude and ineffective.

			// FIXME char[] -> String -> char[] oops.
			String searchKey;
			int lastSymbol = phrase.LastIndexOfAny( CharacterGrouping.GroupingSymbol.ToString().ToCharArray() );

			if( lastSymbol > -1 )
				searchKey = phrase.Substring( lastSymbol + 1, phrase.Length - lastSymbol - 1 ).ToUpper();
			else
				searchKey = phrase.ToUpper();
	
			foreach( String key in words.Keys )
				if(
					// Ensure we only search keys that are longer than
					// the word fragment we have.
					key.Length > searchKey.Length &&
					// Ensure word fragment matches.
					key.IndexOf( searchKey, 0 ) == 0 &&
					// Ensure next letter is in chosen grouping.
					next.IndexOf( key[ searchKey.Length ] ) > -1 )
					// Remember that the value entry is actually the priority int.
					// Preprend it to the textual key so that numerically lower
					// priorities come first as sorted keys.
					results.Add( words[ key ] + key, key );
		
			#region Search debug
			//String suggestions = "";

			//foreach( DictionaryEntry de in results )
			//	suggestions += "\t" + de.Key.ToString() + "\n";

			//Console.Out.WriteLine( "Search on \"{0}\" for \"{1}\" found {2} results:\n{3}", new Object[] { searchKey, next, results.Count, suggestions } );
			#endregion

			// If there are any results, use the first.
			// It'll have the highest priority, or will
			// be alphabetically earliest.
			if( results.Count > 0 )
				return ((String) results.GetByIndex( 0 ))[ searchKey.Length ];

			// No valid results found. Return first letter of grouping.
			return next[ 0 ];
		}

	}
}