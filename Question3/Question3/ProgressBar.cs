using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question3
{
    public partial class ProgressBar : Form
    {
        public Action task
        {
            get;
            set;
        }
        public ProgressBar(Action task)
        {
            InitializeComponent();
            this.task = task ?? throw new ArgumentNullException();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(task).ContinueWith(t => {
                Close();
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
