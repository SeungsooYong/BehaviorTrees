﻿// Copyright(c) 2015-2019 Eugeny Novikov. Code under MIT license.

using System;
using System.IO;
using System.Windows.Forms;
using BehaviorTrees;
using BehaviorTrees.Collections;
using BehaviorTrees.Engine;

namespace BehaviorTreesEditor
{
	public partial class BTEditorForm : Form
	{
		public BTScript Data
		{
			get { return scriptEditorControl.Script; }
			set { scriptEditorControl.Script = value; }
		}

		public BTEditorForm()
		{
			InitializeComponent();
			scriptEditorControl.ScriptNameChanged += (s, e) => UpdateCaption(Data);
			Engine.Instance.SceneLoaded += (s, e) => { statusLabel.Text = "Scene loaded."; };
			statusLabel.Text = "Load or create new Behavior Tree";
			scriptEditorControl.LoadEmpty();
		}

		public void LoadData(BTScript data)
		{
			scriptEditorControl.LoadData(data);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void BTEditorForm_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					scriptEditorControl.ExecuteScript();
					break;
			}
		}

		private void UpdateCaption(BTScript data)
		{
			Text = "Behavior Tree Editor - [ " + Path.GetFileName(data.FileName) + " ]";
		}
	}
}
