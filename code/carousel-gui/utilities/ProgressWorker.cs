using carousel_gui.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace carousel_gui.utilities
{
    public class ProgressWorker
    {
        private BackgroundWorker _Worker;

        public ProgressWorker()
        {
            _Worker = new BackgroundWorker();
        }

        public async Task Run(Action<CancellationTokenSource> action)
        {
            var cts = new CancellationTokenSource();
            var progressBar = new ProgressForm(cts);

            _Worker.DoWork += new DoWorkEventHandler((sender, e) =>
            {
                try
                {
                    action(cts);
                }
                catch (AggregateException aggs)
                {
                    foreach (var exes in aggs.InnerExceptions)
                    {
                        if (exes is TaskCanceledException)
                        {
                        }
                    }
                }
            });

            _Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, e) =>
            {
                progressBar.Close();
            });

            _Worker.RunWorkerAsync(action);

            progressBar.ShowDialog();
        }
    }
}
