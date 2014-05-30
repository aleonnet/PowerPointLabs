﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;
using PPExtraEventHelper;
using Point = System.Drawing.Point;

namespace PowerPointLabs.Views
{
    public partial class InShowControl : Form
    {
        private enum ButtonStatus
        {
            Idle,
            Rec
        }

        private ButtonStatus _status;
        
        private int _currentSlide;
        private int _currentScriptIndex;
        private SlideShowWindow _slideShowWindow;

        public InShowControl()
        {
            InitializeComponent();
            
            // set the background transparency
            BackColor = Color.Magenta;
            TransparencyKey = Color.Magenta;

            _slideShowWindow = Globals.ThisAddIn.Application.ActivePresentation.SlideShowWindow;

            // get slide show window
            IntPtr slideShowWindow = new IntPtr(_slideShowWindow.HWND);
            
            Native.RECT rec;
            Native.GetWindowRect(new HandleRef(new object(), slideShowWindow), out rec);
            
            Location = new Point(rec.Right - Width, rec.Bottom - Height- 50);

            _currentScriptIndex = 0;
        }

        private void RecButtonClick(object sender, EventArgs e)
        {
            switch (_status)
            {
                case ButtonStatus.Idle:
                    recButton.Text = "Stop and Advance";
                    Globals.ThisAddIn.recorderTaskPane.RecButtonIdleHandler();
                    break;

                case ButtonStatus.Rec:
                    recButton.Text = "Record";
                    var currentSlide = _slideShowWindow.View.Slide;
                    var slideRelativeIndex = currentSlide.SlideID - 256;
                    break;
            }
        }
    }
}