//------------------------------------------------------------------------------
// <copyright file="ControlWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace MakeCommands
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("1381fb1c-e1de-4296-b390-f0d397aa4af1")]
    public class ControlWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlWindow"/> class.
        /// </summary>
        public ControlWindow() : base(null)
        {
            this.Caption = "ControlWindow";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new ControlWindowControl();
        }
    }
}
