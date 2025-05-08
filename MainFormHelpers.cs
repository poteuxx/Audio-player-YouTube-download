#pragma warning disable
using AudioPlayer;
using System;
using System.Windows.Forms;

internal static class MainFormHelpers
{
    [STAThread]
    static void Main()
    {
        Application.Run(new MainForm());
    }
}