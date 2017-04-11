using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasWindowsForms
{
    class Prompt
    {     

        public Boolean CreateMyForm()
        {
            Form form1 = new Form();

            Button button1 = new Button();
            Button button2 = new Button();

            button1.Text = "Facil";

            button1.Location = new System.Drawing.Point(40, 60);
 
            button2.Text = "Dificil";
            button2.Location = new Point(button1.Left+130, 60);

            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
   
            form1.Text = "Seleciona la dificultad";
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;

            form1.AcceptButton = button1;
            form1.CancelButton = button2;
            
            form1.StartPosition = FormStartPosition.CenterScreen;

            form1.Controls.Add(button1);
            form1.Controls.Add(button2);

            form1.ShowDialog();

            if (form1.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
