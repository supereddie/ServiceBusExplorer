using Abstractions;
using System;
using System.IO;
using System.Windows.Forms;

namespace ServiceBusExplorer.Forms
{
    public partial class ChangeQueueStatusForm : Form
    {
        public BaseEntityStatus EntityStatus { get; private set; }

        public ChangeQueueStatusForm(BaseEntityStatus entityCurrentStatus)
        {
            InitializeComponent();
            SetSelected(entityCurrentStatus);
        }

        private void SetSelected(BaseEntityStatus entityStatus)
        {
            if (!cbStatus.Items.Contains(entityStatus.ToString()))
            {
                throw new InvalidDataException($"Unexpected value {entityStatus} passed");
            }
            EntityStatus = entityStatus;
            cbStatus.SelectedIndex = cbStatus.Items.IndexOf(entityStatus.ToString());
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            EntityStatus = (BaseEntityStatus)Enum.Parse(typeof(BaseEntityStatus), cbStatus.SelectedItem.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
