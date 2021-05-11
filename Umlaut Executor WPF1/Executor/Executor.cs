using P3.Core.Executor.Enums;
using P3.Core.Executor.Interfaces;
using P3.Core.Executor.PubSubs;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Umlaut_Executor_WPF1.Executor
{
    /// <summary>
    /// This is the executor class that will implement the IPlugin interface
    /// </summary>
    public class Executor : IPlugin, IMenuBar //==> uncomment IMenuBar if you dont want to implement menubar
    {
        MenuItem _FileMenu;
        private IEventAggregator _iEventAggregator;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="args">arguments</param>
        public Executor()
        {
            ExecutionMode = GUIMode.Normal;
            EnableLoggingInUI = true;
            _FileMenu = new MenuItem() { Header = "File" };
            var exit = new MenuItem() { Header = "Exit" };
            exit.Click += Exit_Click;
            _FileMenu.Items.Add(exit);
        }

        /// <summary>
        /// Async executable function.
        /// </summary>
        /// <param name="args">arguments from command line</param>
        private async Task StartLongRunningExecution(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(100);

                if (i < 49)
                {
                    NotifyProgressChanged(true, 0, 100, i, ProgressType.Default);
                }
                else
                {
                    NotifyProgressChanged(false, 0, 100, i, ProgressType.Error);
                }

                WriteToLog(i.ToString(), LogType.Information);
            }

            WriteToLog("Hello", LogType.Information);
            NotifyCloseApplication();
        }

        #region Logging
        private void WriteToLog(string msg, LogType traceType)
        {
            if (traceType == LogType.Information)
            {
                System.Diagnostics.Trace.TraceInformation(msg);
            }
            else if (traceType == LogType.Warning)
            {
                System.Diagnostics.Trace.TraceWarning(msg);
            }
            else if (traceType == LogType.Warning)
            {
                System.Diagnostics.Trace.TraceWarning(msg);
            }
        }
        #endregion

        #region IMenuBar
        public List<MenuItem> MenuItems
        {
            get
            {
                return new List<MenuItem>() {
                    _FileMenu
                };
            }
        }
        #endregion

        #region IPlugin
        /// <summary>
        /// The function for execution should be done here, the execution runs async
        /// </summary>
        /// <param name="args">Application argements</param>
        /// <returns>Task</returns>
        public Task ExecuteAsync(string[] args)
        {
            return Task.Factory.StartNew(() => StartLongRunningExecution(args));
        }

        /// <summary>
        /// This is the initialization function for the plugin. 
        /// This function is first invoked to allwo the plugin to initialize resources
        /// </summary>
        /// <param name="iEventAggregator">Prism.Events.IEventAggregator : handle PubSub events exchange</param>
        public void Init(IEventAggregator iEventAggregator)
        {
            _iEventAggregator = iEventAggregator;
        }

        /// <summary>
        /// Title of the plugin
        /// </summary>
        public string Title => "Umlaut_Executor_WPF1";

        /// <summary>
        /// flag to indicate if the log messages should be shown in the text box
        /// </summary>
        public bool EnableLoggingInUI { get; }

        /// <summary>
        /// Help url of the plugin
        /// </summary>
        public Uri HelpLink => new Uri("");

        /// <summary>
        /// Assembly version of the plugin
        /// </summary>
        public Version Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        public GUIMode ExecutionMode { get; }
        #endregion

        #region Menu Events
        private void Exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NotifyCloseApplication();
        }
        #endregion

        #region Publishers

        /// <summary>
        /// Raise a Publish event of type P3.Windows.Modules.ExecutorCoreLib.PubSubs.NotifyCloseApplicationEvent to close the application
        /// </summary>
        public void NotifyCloseApplication()
        {
            _iEventAggregator.GetEvent<NotifyCloseApplicationEvent>().Publish(new NotifyCloseApplicationEvent());
        }

        /// <summary>
        /// Raise a Publish event of type P3.Windows.Modules.ExecutorCoreLib.PubSubs.NotifyProgressChangedEvent to update the progress bar of the application
        /// </summary>
        public void NotifyProgressChanged(bool isIndeterminate, int minValue, int maxValue, int curValue, ProgressType type)
        {
            _iEventAggregator.GetEvent<NotifyProgressChangedEvent>().Publish(new NotifyProgressChangedEvent(isIndeterminate, minValue, maxValue, curValue, type));
        }

        #endregion

        #region IDisposable
        /// <summary>
        /// Handle all disposable objects
        /// </summary>
        public void Dispose()
        {
            //Dispose any objects created by you. 
            //Do not dispose injected objects, they will be automatically disposed by the ExecutorApp
        }
        #endregion
    }
}
