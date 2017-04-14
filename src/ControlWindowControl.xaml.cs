//------------------------------------------------------------------------------
// <copyright file="ControlWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace MakeCommands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ControlWindowControl.
    /// </summary>
    public partial class ControlWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlWindowControl"/> class.
        /// </summary>
        public ControlWindowControl()
        {
            this.InitializeComponent();
        }

        private void run()
        {
            var stringToType = keysBox.Text;
            int delay;
            int subsequentDelay;
            if (!Int32.TryParse(delayBox.Text, out delay))
            {
                delay = 0;
            }
            if (!Int32.TryParse(subsequentDelayBox.Text, out subsequentDelay))
            {
                subsequentDelay = delay;
            }

            Task.Run(async () => 
            {
                bool firstRun = true;
                foreach (var character in stringToType)
                {
                    runButton.Dispatcher.BeginInvoke((Action)(() => {
                        VisualStudioModule.ExecuteCommand("Type", character.ToString());
                    }));
                    if (firstRun && delay > 0)
                    {
                        await Task.Delay(delay);
                        firstRun = false;
                    }
                    else if (!firstRun && subsequentDelay > 0)
                    {
                        await Task.Delay(subsequentDelay);
                    }
                }
            });
        }

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            run();
        }
        private void keysBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                e.Handled = true;
                run();
            }
        }

        private void delayBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                e.Handled = true;
                run();
            }
        }

        private void subsequentDelayBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                e.Handled = true;
                run();
            }
        }

        private void delayBox_GotFocus(object sender, RoutedEventArgs e)
        {
            delayBox.SelectAll();
        }

        private void subsequentDelayBox_GotFocus(object sender, RoutedEventArgs e)
        {
            subsequentDelayBox.SelectAll();
        }
    }
}