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

using NUnit.Framework;

namespace LothianProductions.Quickie {

	/// <summary>
	/// Test case for the PhraseBuilder mechanism.
	/// </summary>
	[TestFixture()]
	public class PhraseBuilderTests {

		protected PhraseBuilder mPhrase = new PhraseBuilderImpl();

		[SetUp()]
		public void Init() {
			// Use dummy word provider to speed up tests.
			mPhrase.Words = new WordsDummyProvider().GetWords();
		}

		[Test()]
		public void TestAddClearDeleteCharacter() {
			int phraseLength = mPhrase.ToString().Length;

			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );

			// Test that adding a character works.
			Assert.AreEqual( phraseLength + 1, mPhrase.ToString().Length, "Adding a character grouping didn't increase the phrase size." );

			mPhrase.DeleteCharacter();

			// Test that removing a character works.
			Assert.AreEqual( phraseLength, mPhrase.ToString().Length, "Deleting a character grouping didn't decrease the phrase size." );

			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );
			mPhrase.Clear();

			// Test that clearing works.
			Assert.AreEqual( phraseLength, mPhrase.ToString().Length, "Deleting a character grouping didn't decrease the phrase size." );
		}

		[Test()]
		public void TestCasing() {
			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );
			String caseChar = mPhrase.ToString();

			mPhrase.DeleteCharacter();
			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );

			// Test two characters have the same case.
			Assert.AreEqual( caseChar, mPhrase.ToString(), "Characters changed or changed case somehow." );

			// Toggle the case.
			mPhrase.ToggleCase();

			// Test case-toggling doesn't modify phrase.			
			Assert.AreEqual( caseChar, mPhrase.ToString(), "Change of case modified existing phrase." );
			mPhrase.DeleteCharacter();

			// Test case-toggling changed case.
			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );
			Assert.IsTrue( caseChar != mPhrase.ToString(), "Change of case didn't change case of characters." );

			caseChar = mPhrase.ToString();
			mPhrase.DeleteCharacter();

			// Test case-toggle has been persisted.
			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );

			Assert.AreEqual( caseChar, mPhrase.ToString(), "Characters changed or changed case somehow." );

			// Put the case back.
			mPhrase.ToggleCase();
		}

		[Test()]
		public void TestSuggestion() {

			mPhrase.Words.Clear();
			mPhrase.Words.Add( "WOODS", 1 );
			mPhrase.Words.Add( "WONDER", 3 );
			mPhrase.Words.Add( "WOMBAT", 2 );

			mPhrase.Clear();
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );

			// WOODS has highest priority, so it should be chosen.
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			Assert.AreEqual( "WOO", mPhrase.ToString(), "Testing WOODS priority." );

			mPhrase.Words.Clear();
			mPhrase.Words.Add( "WOODS", 3 );
			mPhrase.Words.Add( "WONDER", 2 );
			mPhrase.Words.Add( "WOMBAT", 1 );

			mPhrase.Clear();
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );

			// WOMBAT has highest priority, so it should be chosen.
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			Assert.AreEqual( "WOM", mPhrase.ToString(), "Testing WOMBAT priority." );

			mPhrase.Words.Clear();
			mPhrase.Words.Add( "WOODS", 2 );
			mPhrase.Words.Add( "WONDER", 1 );
			mPhrase.Words.Add( "WOMBAT", 3 );

			mPhrase.Clear();
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );

			// WONDER has highest priority, so it should be chosen.
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			Assert.AreEqual( "WON", mPhrase.ToString(), "Testing WONDER priority." );

			mPhrase.Words.Clear();
			mPhrase.Words.Add( "WOODS", 1 );
			mPhrase.Words.Add( "WONDER", 1 );
			mPhrase.Words.Add( "WOMBAT", 1 );

			mPhrase.Clear();
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );

			// WOMBAT has highest priority, so it should be chosen.
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			Assert.AreEqual( "WOM", mPhrase.ToString(), "Testing alphabetical priority." );
		}

		[Test()]
		public void TestNextCharacter() {
			mPhrase.Words.Clear();
			mPhrase.Clear();

			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );
			Assert.AreEqual( "A", mPhrase.ToString(), "Testing for A in next-character cycle." );

			mPhrase.NextCharacter();
			Assert.AreEqual( "B", mPhrase.ToString(), "Testing for B in next-character cycle." );

			mPhrase.NextCharacter();
			Assert.AreEqual( "C", mPhrase.ToString(), "Testing for C in next-character cycle." );

			mPhrase.NextCharacter();
			Assert.AreEqual( "A", mPhrase.ToString(), "Testing for A (again) in next-character cycle." );
		}

		[Test()]
		public void TestPunctuationFirst() {

			// Ensure punctuation at start of phrase doesn't break anything.
			mPhrase.Words.Clear();
			mPhrase.Words.Add( "WONDER", 1 );

			mPhrase.Clear();
			mPhrase.AddCharacter( CharacterGrouping.GroupingSymbol );
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );

			// WONDER has highest priority, so it should be chosen.
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			Assert.AreEqual( " WON", mPhrase.ToString(), "Testing WONDER priority." );
		}

	}
}