using Neonode.Forms;
using TripleSoftware.NeoRhythm;
using System;
using System.Windows.Forms;

internal static class Program
{
    // Methods
    [MTAThread]
    private static void Main()
    {
        string applicationIdentifier = "NeoRhythm_75B462B3-689A-4bee-BCA9-47A0842C3C2C";

        using (SingleInstance instance = new SingleInstance(applicationIdentifier)) {
            if (instance.AlreadyRunning) {
                instance.TryActivatePreviousInstance(applicationIdentifier);
            } else {
                MainForm mainForm = new MainForm();
                mainForm.Text = applicationIdentifier;
                try {
                    Application.Run(mainForm);
                } catch (Exception) {
                }
            }
        }
    }
}