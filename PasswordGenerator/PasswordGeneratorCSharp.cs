/*
 * Created by SharpDevelop.
 * User: teraxl
 * Date: 24.01.2019
 * Time: 19:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Tracing;
using System.Windows.Forms;
//using System.Timers;
using System.Threading;

namespace PasswordGenerator
{
	public class PasswordGeneratorCSharp
	{
		private const string ENG_SYM = "abcdefghijklmnopqrstuvwxyz";
		private const string RUS_SYM = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
		private const string DIGITS = "0123456789";
		private const string PUNCTUATION = "!@#$%&*()_+-=[]|,./?><";
		public bool useEngSym;
		public bool useRusSym;
		public bool useDigits;
		public bool usePunctuation;
		
		public static int x = 0;
		public static TimerCallback tm = new TimerCallback(timerCounter);
		System.Threading.Timer timer = new System.Threading.Timer(tm, null, 0, 500);
		public static int randNano = 0;
		
		public static void timerCounter(object obj){
			
			Trace.TraceInformation("{0}", nanoTime());
				randNano = (int)obj;
		}
		
		public static int nanoTime() {
			long nano = 10000L * Stopwatch.GetTimestamp();
			nano /= TimeSpan.TicksPerMillisecond;
			return (int)nano;
			
		}
		
		public PasswordGeneratorCSharp()
		{
			throw new Exception("Empty constructor is not supported.");
		}
		public PasswordGeneratorCSharp(PassGenBuilder builder){
			this.useDigits = builder.useDigits;
			this.useEngSym = builder.useEngSym;
			this.usePunctuation = builder.usePunctuation;
			this.useRusSym = builder.useRusSym;
		}
		
		public class PassGenBuilder {
			public bool useEngSym;
			public bool useRusSym;
			public bool useDigits;
			public bool usePunctuation;
			
			public PassGenBuilder() {
				this.useEngSym = false;
				this.useRusSym = false;
				this.useDigits = false;
				this.usePunctuation = false;
			}
			public PassGenBuilder m_useEngSym(bool engSym){
				this.useEngSym = engSym;
				return this;
			}
			public PassGenBuilder m_useRusSym(bool rusSym){
				this.useRusSym = rusSym;
				return this;
			}
			public PassGenBuilder m_useDigits(bool digits){
				this.useDigits = digits;
				return this;
			}
			public PassGenBuilder m_usePunctSym(bool punctSym){
				this.usePunctuation = punctSym;
				return this;
			}
			public PasswordGeneratorCSharp build() {
				return new PasswordGeneratorCSharp(this);
			}
		}
		
		public string resultGeneratePassword(int c_lenght){
			
			if (c_lenght < 0){
				return "";
			}
			
			var password = new StringBuilder((int)c_lenght);
			var random = new Random((int)nanoTime());
			
			var catetogry_Sympb = new List<String>(4);
			if (useDigits){
				catetogry_Sympb.Add(DIGITS);
			}
			if (useEngSym){
				catetogry_Sympb.Add(ENG_SYM);
			}
			if (useRusSym){
				catetogry_Sympb.Add(RUS_SYM);
			}
			if (usePunctuation){
				catetogry_Sympb.Add(PUNCTUATION);
			}
			
			for (int i = 0; i < c_lenght; i++){
				String c_getSys = catetogry_Sympb[random.Next(catetogry_Sympb.Count)];
				int position = (int)(random.Next(c_getSys.Count()));
				password.Append(c_getSys[position]);
			}
			
			return password.ToString();
		}
		
		public string returnString(PassGenBuilder passgen, int numDigits = 8){
			passgen = new PassGenBuilder();
			switch(numDigits){
				case 8:
					passgen.m_useDigits(true);
					passgen.m_useEngSym(true);
					break;
			}
			return resultGeneratePassword(numDigits);
		}
		
	}
}
