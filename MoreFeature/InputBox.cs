using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreFeature
{
    public class InputBox
    {
        public static InputBoxResult Show(string text, string title = "", string firstText = "")
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox(text, title, firstText);
            if (result == null)
            {
                return new InputBoxResult(InputBoxDialogResult.Cancel, null);
            }
            else
            {
                if (result == "")
                {
                    return new InputBoxResult(InputBoxDialogResult.Cancel, null);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        return new InputBoxResult(InputBoxDialogResult.Cancel, null);
                    }
                    else
                    {
                        return new InputBoxResult(InputBoxDialogResult.OK, result);
                    }
                }
            }
        }
    }

    public enum InputBoxDialogResult
    {
        OK = 0,
        Cancel = 1
    }

    public class InputBoxResult
    {
        public InputBoxResult(InputBoxDialogResult result, string textBox)
        {
            this.DialogResult = result;
            this.Text = textBox;
        }

        public InputBoxDialogResult DialogResult { get; }

        public string Text { get; }
    }
}
