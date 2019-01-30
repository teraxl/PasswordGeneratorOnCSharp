/*
 * Created by SharpDevelop.
 * User: К3
 * Date: 23.01.2019
 * Time: 14:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PasswordGenerator;

namespace PasswordGenerator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		void Button1Click(object sender, EventArgs e)
		{
			var pwdG = new PasswordGeneratorCSharp.PassGenBuilder();
			var pwd = pwdG.build();
			
			textBox1.Text = pwd.returnString(pwdG, 8);
			
//			textBox1.Text = new PasswordGeneratorCSharp.PassGenBuilder()
//				.m_useDigits(true)
//				.m_useEngSym(true)
//				.build().resultGeneratePassword((int)this.numericUpDown1.Value);
		}
	}
}
