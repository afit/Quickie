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
using System.IO;
using System.Text;
using System.Xml;

namespace LothianProductions.Quickie {

	public interface WordsProvider {
		Hashtable GetWords();
	}

	public class WordsXmlProvider : WordsProvider {

		public const String XML_FILE = @"C:\Words.xml";

		public Hashtable GetWords() {

			Hashtable words = new Hashtable();
			XmlTextReader reader = new XmlTextReader( XML_FILE );

			// FIXME No exception handling.
			while( reader.Read() )
				switch( reader.NodeType ) {
					case XmlNodeType.Element:

						if( reader.HasAttributes ) {
							String priority = null, name = null;

							// FIXME Assumes well-formed, not robust.
							for( int i = 0; i < reader.AttributeCount; i++ ) {
								reader.MoveToAttribute( i );

								if( reader.Name == "priority" )
									priority = reader.Value;
								
								if( reader.Name == "value" )
									// FIXME Uppercasing on the way in is going
									// to be unecessarily costly.
									name = reader.Value.ToUpper();

								// Faster to check than to catch.
								if( name != null && priority != null && ! words.ContainsKey( name ) )
									words.Add( name, priority );
							}
						}
						break;
				}

			return words;
		}
	}

	public class WordsDummyProvider : WordsProvider {

		public Hashtable GetWords() {
			Hashtable hash = new Hashtable();

			hash.Add( "HELLO", 1 );
			hash.Add( "WOODS", 2 );
			hash.Add( "WORLD", 1 );
			hash.Add( "WOMBAT", 3 );
			hash.Add( "MY", 1 );
			hash.Add( "NAME", 1 );
			hash.Add( "IS", 1 );
			hash.Add( "AIDAN", 1 );

			return hash;
		}

	}
}