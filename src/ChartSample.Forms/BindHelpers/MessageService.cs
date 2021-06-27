using System.Windows.Forms;

namespace ChartSample.Forms.BindHelpers
{
    public class MessageService : IMessageService
    {
        public void OkMessage(string message)
        {
            MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult QuestionMessage(string message)
        {
            return MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question );
        }
    }
}