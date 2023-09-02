using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Momento_Pattern {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        // Create a caretaker that contains the collection
        Caretaker caretaker = new Caretaker();

        // The originator sets the value for the statement
        Originator originator = new Originator();

        int safeFiles = 0, currentStatement = -1;

        public MainWindow() {
            InitializeComponent();


            savebtn.Click += (s, e) => {

                string text = textbox.Text;
                originator.set(text);
                caretaker.AddMemento(originator.StoreInMemento());

                safeFiles++;
                currentStatement++;

                Console.WriteLine($"Saved Files {safeFiles} \n");
                undobtn.IsEnabled = true;
            };

            undobtn.Click += (s, e) => {
                if (currentStatement >=0) {
                    currentStatement--;
                    string textBoxString = originator.RestoreFromMemento(caretaker.GetMemento(currentStatement));

                    textbox.Text = textBoxString;
                    redobtn.IsEnabled = true;
                }
                else {
                    undobtn.IsEnabled = false;
                }
            };

            redobtn.Click += (s, e) => {
                if ((safeFiles-1)>currentStatement) {
                    currentStatement++;
                    string textBoxString = originator.RestoreFromMemento(caretaker.GetMemento(currentStatement));
                    textbox.Text = textBoxString;
                    undobtn.IsEnabled = false;

                }
                else {
                    redobtn.IsEnabled = false;
                }
                undobtn.IsEnabled = true;
            };

        }
    }
}
