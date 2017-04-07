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

        private void runButton_Click(object sender, RoutedEventArgs e)
        {
            var stringToType = keysBox.Text;
            int delay;
            if (!Int32.TryParse(delayBox.Text, out delay))
            {
                delay = 0;
            }

            Task.Run(async () => {

                foreach (var character in stringToType)
                {
                    if (delay > 0)
                    {
                        await Task.Delay(delay);
                    }
                    runButton.Dispatcher.BeginInvoke((Action)(() => {
                        VisualStudioModule.ExecuteCommand("Type", character.ToString());
                    }));
                }
            });
        }
    }
}