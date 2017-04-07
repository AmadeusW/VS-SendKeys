using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Editor;
using WpfSendKeys;
using System.Windows;

namespace MakeCommands
{
    public static class VisualStudioModule
    {
        private static DTE envDte;
        private static IWpfTextView _currentTextView;

        public static void Initialize(DTE dte)
        {
            envDte = dte;
        }

        public static void ExecuteCommand(string commandName, string commandArgs = "")
        {
            var test = commandName;
            try
            {
                var textView = _currentTextView as UIElement;
                SendKeys.Send(textView, commandArgs);
            }
            catch (Exception ex)
            {
                envDte.StatusBar.Text = $"Error executing command: " + ex.Message;
            }
        }

        internal static void SetTextView(IWpfTextView textView)
        {
            _currentTextView = textView;
        }
    }
}
