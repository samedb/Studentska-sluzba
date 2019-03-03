using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.Helpers
{
    public class LetterOnlyTextBox: TextBox
    {
        public LetterOnlyTextBox()
            : base()
        {
            this.TextChanged += new TextChangedEventHandler(samoSlova);
        }

        private void samoSlova(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = new string(tb.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
            tb.SelectionStart = tb.Text.Length;
        }
    }
}
