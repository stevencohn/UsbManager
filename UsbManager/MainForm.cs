//************************************************************************************************
// Copyright © 2010 Steven M. Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace UsbManagerDemo
{
	using System;
	using System.Windows.Forms;
	using iTuner;


	public partial class MainForm : Form
	{
		private static readonly string CR = Environment.NewLine;
	
		private UsbManager manager;


		public MainForm ()
		{
			InitializeComponent();

			manager = new UsbManager();
			UsbDiskCollection disks = manager.GetAvailableDisks();

			textBox.AppendText(CR);
			textBox.AppendText("Available USB disks" + CR);

			foreach (UsbDisk disk in disks)
			{
				textBox.AppendText(disk.ToString() + CR);
			}

			textBox.AppendText(CR);

			manager.StateChanged += new UsbStateChangedEventHandler(DoStateChanged);
		}


		private void DoStateChanged (UsbStateChangedEventArgs e)
		{
			textBox.AppendText(e.State + " " + e.Disk.ToString() + CR);
		}
	}
}
