using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DancingBar
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private IEnumerable<Control> _listProgressBar;
        
        public Form1()
        {
            InitializeComponent();
            _listProgressBar = this.Controls.OfType<Control>().Where(p => p is CustomVerticalProgressBar);
        }

        private async void buttonRun_Click(object sender, EventArgs e)
        {
            buttonRun.Enabled = false;
            _cancellationTokenSource = new CancellationTokenSource();
            await RunDanceAsync(_cancellationTokenSource.Token);
            buttonRun.Enabled = true;
        }

        private async Task RunDanceAsync(CancellationToken cancellationToken = default)
        {
            var listTask = new List<Task>();

            foreach (CustomVerticalProgressBar item in _listProgressBar)
            {
                var task = ChangeProgressBar(item, cancellationToken);
                listTask.Add(task);
            }
            await Task.WhenAll(listTask);

        }
        private async Task ChangeProgressBar(CustomVerticalProgressBar progressBar, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var rnd = new Random();
                progressBar.Value = rnd.Next(0, progressBar.MaxValue + 1);
                progressBar.Color = RandomColor.GetColor();
                await Task.Delay(150);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
