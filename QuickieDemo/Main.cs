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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using LothianProductions.Quickie;

namespace Quickie {

	public class frmMain : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnSymbol;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCase;
		private System.Windows.Forms.Button btnBackspace;
		private System.Windows.Forms.Button btnAbc;
		private System.Windows.Forms.Button btnDef;
		private System.Windows.Forms.Button btnGhi;
		private System.Windows.Forms.Button btnPqrs;
		private System.Windows.Forms.Button btnMno;
		private System.Windows.Forms.Button btnJkl;
		private System.Windows.Forms.Button btnWxyz;
		private System.Windows.Forms.Button btnTuv;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblText;

		protected PhraseBuilder mPhrase = new PhraseBuilderImpl();

		public frmMain() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblText = new System.Windows.Forms.Label();
			this.btnAbc = new System.Windows.Forms.Button();
			this.btnDef = new System.Windows.Forms.Button();
			this.btnGhi = new System.Windows.Forms.Button();
			this.btnPqrs = new System.Windows.Forms.Button();
			this.btnMno = new System.Windows.Forms.Button();
			this.btnJkl = new System.Windows.Forms.Button();
			this.btnSymbol = new System.Windows.Forms.Button();
			this.btnWxyz = new System.Windows.Forms.Button();
			this.btnTuv = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCase = new System.Windows.Forms.Button();
			this.btnBackspace = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblText
			// 
			this.lblText.Location = new System.Drawing.Point(16, 16);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(168, 24);
			this.lblText.TabIndex = 1;
			// 
			// btnAbc
			// 
			this.btnAbc.Location = new System.Drawing.Point(16, 48);
			this.btnAbc.Name = "btnAbc";
			this.btnAbc.Size = new System.Drawing.Size(48, 32);
			this.btnAbc.TabIndex = 2;
			this.btnAbc.Text = "ABC";
			this.btnAbc.Click += new System.EventHandler(this.btnAbc_Click);
			// 
			// btnDef
			// 
			this.btnDef.Location = new System.Drawing.Point(72, 48);
			this.btnDef.Name = "btnDef";
			this.btnDef.Size = new System.Drawing.Size(48, 32);
			this.btnDef.TabIndex = 3;
			this.btnDef.Text = "DEF";
			this.btnDef.Click += new System.EventHandler(this.btnDef_Click);
			// 
			// btnGhi
			// 
			this.btnGhi.Location = new System.Drawing.Point(128, 48);
			this.btnGhi.Name = "btnGhi";
			this.btnGhi.Size = new System.Drawing.Size(48, 32);
			this.btnGhi.TabIndex = 4;
			this.btnGhi.Text = "GHI";
			this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
			// 
			// btnPqrs
			// 
			this.btnPqrs.Location = new System.Drawing.Point(128, 88);
			this.btnPqrs.Name = "btnPqrs";
			this.btnPqrs.Size = new System.Drawing.Size(48, 32);
			this.btnPqrs.TabIndex = 7;
			this.btnPqrs.Text = "PQRS";
			this.btnPqrs.Click += new System.EventHandler(this.btnPqrs_Click);
			// 
			// btnMno
			// 
			this.btnMno.Location = new System.Drawing.Point(72, 88);
			this.btnMno.Name = "btnMno";
			this.btnMno.Size = new System.Drawing.Size(48, 32);
			this.btnMno.TabIndex = 6;
			this.btnMno.Text = "MNO";
			this.btnMno.Click += new System.EventHandler(this.btnMno_Click);
			// 
			// btnJkl
			// 
			this.btnJkl.Location = new System.Drawing.Point(16, 88);
			this.btnJkl.Name = "btnJkl";
			this.btnJkl.Size = new System.Drawing.Size(48, 32);
			this.btnJkl.TabIndex = 5;
			this.btnJkl.Text = "JKL";
			this.btnJkl.Click += new System.EventHandler(this.btnJkl_Click);
			// 
			// btnSymbol
			// 
			this.btnSymbol.Location = new System.Drawing.Point(128, 128);
			this.btnSymbol.Name = "btnSymbol";
			this.btnSymbol.Size = new System.Drawing.Size(48, 32);
			this.btnSymbol.TabIndex = 10;
			this.btnSymbol.Text = "_!£";
			this.btnSymbol.Click += new System.EventHandler(this.btnSymbol_Click);
			// 
			// btnWxyz
			// 
			this.btnWxyz.Location = new System.Drawing.Point(72, 128);
			this.btnWxyz.Name = "btnWxyz";
			this.btnWxyz.Size = new System.Drawing.Size(48, 32);
			this.btnWxyz.TabIndex = 9;
			this.btnWxyz.Text = "WXYZ";
			this.btnWxyz.Click += new System.EventHandler(this.btnWxyz_Click);
			// 
			// btnTuv
			// 
			this.btnTuv.Location = new System.Drawing.Point(16, 128);
			this.btnTuv.Name = "btnTuv";
			this.btnTuv.Size = new System.Drawing.Size(48, 32);
			this.btnTuv.TabIndex = 8;
			this.btnTuv.Text = "TUV";
			this.btnTuv.Click += new System.EventHandler(this.btnTuv_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(128, 168);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(48, 32);
			this.btnNext.TabIndex = 13;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCase
			// 
			this.btnCase.Location = new System.Drawing.Point(16, 168);
			this.btnCase.Name = "btnCase";
			this.btnCase.Size = new System.Drawing.Size(48, 32);
			this.btnCase.TabIndex = 11;
			this.btnCase.Text = "A>a";
			this.btnCase.Click += new System.EventHandler(this.btnCase_Click);
			// 
			// btnBackspace
			// 
			this.btnBackspace.Location = new System.Drawing.Point(72, 168);
			this.btnBackspace.Name = "btnBackspace";
			this.btnBackspace.Size = new System.Drawing.Size(48, 32);
			this.btnBackspace.TabIndex = 14;
			this.btnBackspace.Text = "<";
			this.btnBackspace.Click += new System.EventHandler(this.btnBackspace_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(194, 215);
			this.Controls.Add(this.btnBackspace);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnCase);
			this.Controls.Add(this.btnSymbol);
			this.Controls.Add(this.btnWxyz);
			this.Controls.Add(this.btnTuv);
			this.Controls.Add(this.btnPqrs);
			this.Controls.Add(this.btnMno);
			this.Controls.Add(this.btnJkl);
			this.Controls.Add(this.btnGhi);
			this.Controls.Add(this.btnDef);
			this.Controls.Add(this.btnAbc);
			this.Controls.Add(this.lblText);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.Text = "Quickie Demonstration";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.Run(new frmMain());
		}

		#region Form to PhraseBuilder wireups
		private void btnAbc_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingAbc );
			lblText.Text = mPhrase.ToString();
		}

		private void btnDef_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingDef );
			lblText.Text = mPhrase.ToString();
		}

		private void btnGhi_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingGhi );
			lblText.Text = mPhrase.ToString();
		}

		private void btnJkl_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingJkl );
			lblText.Text = mPhrase.ToString();
		}

		private void btnMno_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingMno );
			lblText.Text = mPhrase.ToString();
		}

		private void btnPqrs_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingPqrs );
			lblText.Text = mPhrase.ToString();
		}

		private void btnTuv_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingTuv );
			lblText.Text = mPhrase.ToString();
		}

		private void btnWxyz_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingWxyz );
			lblText.Text = mPhrase.ToString();
		}

		private void btnSymbol_Click(object sender, System.EventArgs e) {
			mPhrase.AddCharacter( CharacterGrouping.GroupingSymbol );
			lblText.Text = mPhrase.ToString();
		}

		private void btnCase_Click(object sender, System.EventArgs e) {
			mPhrase.ToggleCase();
		}

		private void btnBackspace_Click(object sender, System.EventArgs e) {
			mPhrase.DeleteCharacter();
			lblText.Text = mPhrase.ToString();
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			mPhrase.NextCharacter();
			lblText.Text = mPhrase.ToString();
		}

		private void btnWords_Click(object sender, System.EventArgs e) {
			StringBuilder words = new StringBuilder();

			foreach( Object o in mPhrase.Words.Values )
				words.Append( o.ToString() ).Append( ", " );

			MessageBox.Show( this, words.ToString() );
		}
		#endregion
	}
}
