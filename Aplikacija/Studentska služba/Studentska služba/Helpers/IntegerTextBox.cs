using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.Helpers
{
    public class IntegerTextBox: TextBox
    {
        public IntegerTextBox()
            :base()
        {
            this.TextChanged += new TextChangedEventHandler(samoBrojevi);
        }

        private void samoBrojevi(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = new string(tb.Text.Where(c => char.IsDigit(c)).ToArray());
            tb.SelectionStart = tb.Text.Length;
        }
    }
}
