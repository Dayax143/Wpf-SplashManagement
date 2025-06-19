using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfSplashScreen_Licensing_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); // Ensures base WPF startup operations run first

            // Step 1: Create and show the splash window immediately at startup
            var splash = new winSplash();
            splash.Show();

            // Step 2: Create a progress reporter that runs on the UI thread
            var progress = new Progress<(string message, int percent)>(report =>
            {
                // This updates the splash screen with each progress step
                splash.UpdateStatus(report.message, report.percent);
            });

            // Step 3: Perform all loading tasks asynchronously in a background thread
            Task.Run(async () =>
            {
                // Simulated startup tasks with labels and completion percentages
                var tasks = new[]
                {
            ("Loading configuration...", 25),
            ("Validating connection...", 50),
            ("Loading modules...", 75),
            ("Finishing setup...", 100)
        };

                // Loop through each task and report its status back to the UI
                foreach (var (msg, val) in tasks)
                {
                    // Send status message and percent complete to splash screen
                    (progress as IProgress<(string, int)>)?.Report((msg, val));

                    await Task.Delay(800); // Simulate actual time spent doing work
                }

                // Step 4: Once all tasks are done, switch back to UI thread to show the main window
                splash.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow(); // Create the main application window
                    mainWindow.Show();                 // Show the main window
                    splash.Close();                    // Close the splash screen
                });
            });
        }
    }
    }
