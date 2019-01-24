/*
 * Created by SharpDevelop.
 * User: teraxl
 * Date: 24.01.2019
 * Time: 19:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PasswordGenerator
{
	public class PasswordGeneratorCSharp
	{
		
		
		private const string ENG_SYM = "abcdefghijklmnopqrstuvwxyz";
		private const string RUS_SYM = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
		private const string DIGITS = "0123456789";
		private const string PUNCTUATION = "!@#$%&*()_+-=[]|,./?><";
		private bool useEngSym;
		private bool useRusSym;
		private bool useDigits;
		private bool usePunctuation;
		
		public PasswordGeneratorCSharp()
		{
			throw new ArgumentNullException("Empty constructor is not supported.");
		}
		
		public static class PassGenBuilder {
			private static bool useEngSym;
			private static bool useRusSym;
			private static bool useDigits;
			private static bool usePunctuation;
			
			static PassGenBuilder() {
				this.useEngSym = false;
				this.useRusSym = false;
				this.useDigits = false;
				this.usePunctuation = false;
			}
			public static PassGenBuilder m_useEngSym(bool engSym){
				PassGenBuilder.useEngSym = engSym;
				return this;
			}
			public static PassGenBuilder m_useEngSym(bool rusSym){
				PassGenBuilder.useRusSym = rusSym;
				return this;
			}
			public static PassGenBuilder m_useEngSym(bool rusSym){
				PassGenBuilder.useRusSym = rusSym;
				return this;
			}
			public static PassGenBuilder m_useEngSym(bool rusSym){
				PassGenBuilder.useRusSym = rusSym;
				return this;
			}
		}
		
		public string resultGeneratePassword(int count){
			return "werwer";
		}
		
	}
}
