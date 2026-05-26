using System.Windows.Forms;

namespace Lesson25.Dialogs
{
    public static class InputDialog
    {
        public static string? Show(string title, string promptText, string value = "")
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Скасувати";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 45, 372, 20);
            buttonOk.SetBounds(120, 85, 75, 23);
            buttonCancel.SetBounds(210, 85, 85, 23);

            form.ClientSize = new System.Drawing.Size(400, 125);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            if (form.ShowDialog() == DialogResult.OK) return textBox.Text;
            return null;
        }
    }
}