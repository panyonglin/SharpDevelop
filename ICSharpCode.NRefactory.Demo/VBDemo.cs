﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under MIT X11 license (for details please see \doc\license.txt)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.NRefactory.VB;
using ICSharpCode.NRefactory.VB.Parser;
using ICSharpCode.NRefactory.VB.PrettyPrinter;

namespace ICSharpCode.NRefactory.Demo
{
	/// <summary>
	/// Description of VBDemo.
	/// </summary>
	public partial class VBDemo : UserControl
	{
		public VBDemo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//ParseButtonClick(null, null);
		}
		
		void ParseButtonClick(object sender, EventArgs e)
		{
			using (VBParser parser = new VBParser(new VBLexer(new StringReader(codeView.Text)))) {
				parser.Parse();
				// this retrieves the root node of the result DOM
				if (parser.Errors.Count > 0) {
					MessageBox.Show(parser.Errors.ErrorOutput);
				}
				syntaxTree.Unit = parser.CompilationUnit;
			}
		}
		
		void GenerateCodeButtonClick(object sender, EventArgs e)
		{
			if (syntaxTree.Unit != null) {
				VBNetOutputVisitor visitor = new VBNetOutputVisitor();
				// re-insert the comments we saved from the parser into the output
				using (SpecialNodesInserter.Install(savedSpecials, visitor)) {
					syntaxTree.Unit.AcceptVisitor(visitor, null);
				}
				codeView.Text = visitor.Text.Replace("\t", "  ");
			}
		}
	}
}
