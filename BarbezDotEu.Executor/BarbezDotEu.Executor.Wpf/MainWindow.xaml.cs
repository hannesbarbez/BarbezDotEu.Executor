﻿using BarbezDotEu.Executor.Wpf.Logic;
using System;
using System.Windows;
using System.Windows.Input;

namespace BarbezDotEu.Executor.Wpf
{
    public partial class MainWindow : Window
    {
        private string[] keywords;
        private bool firstClick = true;
        private readonly string[] splitters = new string[] { ",", Environment.NewLine };
        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExecuteAll_Click(object sender, RoutedEventArgs e)
        {
            this.keywords = tbInput.Text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            if (this.keywords != null)
            {
                foreach (var item in this.keywords)
                {
                    Generic.OpenWebsite(item);
                }
            }
        }

        private void BtnOpenNextItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.tbInput.IsEnabled = false;
                if (tbInput.Text != null && !string.IsNullOrEmpty(tbInput.Text))
                {
                    if (firstClick)
                    {
                        this.keywords = tbInput.Text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                        firstClick = false;
                    }
                    if (this.keywords != null)
                    {
                        if (this.keywords.Length > 0)
                        {
                            Generic.OpenWebsite(this.keywords[this.index]);
                            this.index++;
                        }
                    }
                }
                else this.tbInput.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("End of the list! You went through everything.", "All Done.", MessageBoxButton.OK);
                BtnReset_Click(sender, e);
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            this.firstClick = true;
            this.index = 0;
            this.tbInput.IsEnabled = true;
            this.tbInput.Clear();
        }

        private void LblAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Generic.OpenWebsite("http://" + lblAbout.Content);
        }

        private void LblAbout_MouseDown(object sender, TouchEventArgs e)
        {
            Generic.OpenWebsite("http://" + lblAbout.Content);
        }

        private void BtnCopyPastable_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TbCopyPastable.Text);
        }
    }
}
