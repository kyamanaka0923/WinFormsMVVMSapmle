using System.Windows.Forms;

namespace ChartSample.Forms.BindHelpers
{
    public interface IMessageService
    {
        void OkMessage(string message);

        DialogResult QuestionMessage(string message);
    }
}